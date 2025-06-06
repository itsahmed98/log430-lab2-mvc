using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagasinCentral.Data;
using MagasinCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Services
{
    /// <summary>
    /// Implémentation du service métier pour générer le rapport consolidé.
    /// </summary>
    public class RapportService : IRapportService
    {
        private readonly MagasinDbContext _contexte;

        /// <summary>
        /// Constructeur de <see cref="MagasinDbContext"/>.
        /// </summary>
        /// <param name="contexte">Contexte EF Core.</param>
        public RapportService(MagasinDbContext contexte)
        {
            _contexte = contexte;
        }

        /// <inheritdoc />
        public async Task<List<RapportDto>> ObtenirRapportConsolideAsync()
        {
            var listeMagasins = await _contexte.Magasins
                .Include(m => m.Ventes)
                    .ThenInclude(v => v.Produit)
                .Include(m => m.StockProduits)
                    .ThenInclude(sp => sp.Produit)
                .ToListAsync();

            var rapports = new List<RapportDto>();

            foreach (var magasin in listeMagasins)
            {
                decimal chiffreAffaires = magasin.Ventes
                    .Sum(v => v.PrixUnitaire * v.Quantite);

                var topProduits = magasin.Ventes
                    .GroupBy(v => v.Produit)
                    .Select(g => new InfosVenteProduit
                    {
                        NomProduit = g.Key.Nom,
                        QuantiteVendue = g.Sum(x => x.Quantite),
                        TotalVentes = g.Sum(x => x.Quantite * x.PrixUnitaire)
                    })
                    .OrderByDescending(info => info.QuantiteVendue)
                    .Take(3)
                    .ToList();

                var stocksRestants = magasin.StockProduits
                    .Select(sp => new InfosStockProduit
                    {
                        NomProduit = sp.Produit.Nom,
                        QuantiteRestante = sp.Quantite
                    })
                    .ToList();

                rapports.Add(new RapportDto
                {
                    NomMagasin = magasin.Nom,
                    ChiffreAffairesTotal = chiffreAffaires,
                    TopProduits = topProduits,
                    StocksRestants = stocksRestants
                });
            }

            var listeStockCentral = await _contexte.StocksCentraux
                .Include(sc => sc.Produit)
                .ToListAsync();

            var rapportStockCentral = new RapportDto
            {
                NomMagasin = "Stock Central",
                ChiffreAffairesTotal = 0m,
                TopProduits = new List<InfosVenteProduit>(),

                StocksRestants = listeStockCentral
                    .Select(sc => new InfosStockProduit
                    {
                        NomProduit = sc.Produit.Nom,
                        QuantiteRestante = sc.Quantite
                    })
                    .ToList()
            };

            rapports.Add(rapportStockCentral);

            return rapports;
        }
    }
}
