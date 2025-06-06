using MagasinCentral.Data;
using MagasinCentral.Models;
using MagasinCentral.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Services
{
    /// <summary>
    /// Implémentation du service métier
    /// </summary>
    public class ReapprovisionnementService : IReapprovisionnementService
    {
        private readonly MagasinDbContext _contexte;

        public ReapprovisionnementService(MagasinDbContext contexte)
        {
            _contexte = contexte ?? throw new ArgumentNullException(nameof(contexte));
        }

        /// <inheritdoc />
        public async Task<List<StockVue>> GetStocksAsync(int magasinId)
        {
            // Récupérer les stocks locaux et centraux pour un magasin donné
            var stocksLocales = await _contexte.MagasinStocksProduits
                .Where(ms => ms.MagasinId == magasinId)
                .Include(ms => ms.Produit)
                .ToListAsync();

            var stocksCentraux = await _contexte.StocksCentraux
                .Include(sc => sc.Produit)
                .ToListAsync();

            // 3. Construire la liste de StockVue
            var listeStocks = new List<StockVue>();

            foreach (var stockLocal in stocksLocales)
            {
                // Trouver le stock central correspondant
                var sc = stocksCentraux
                    .FirstOrDefault(x => x.ProduitId == stockLocal.ProduitId);

                listeStocks.Add(new StockVue
                {
                    ProduitId = stockLocal.ProduitId,
                    NomProduit = stockLocal.Produit.Nom,
                    QuantiteLocale = stockLocal.Quantite,
                    QuantiteCentral = sc?.Quantite ?? 0
                });
            }

            return listeStocks;
        }

        /// <inheritdoc />
        public async Task CreerDemandeReapprovisionnementAsync(int magasinId, int produitId, int quantiteDemande)
        {
            if (quantiteDemande <= 0)
            {
                throw new ArgumentException("La quantité demandée doit être strictement positive.");
            }

            var magasin = await _contexte.Magasins.FindAsync(magasinId);
            if (magasin == null)
            {
                throw new ArgumentException($"Le magasin d’ID={magasinId} n’existe pas.");
            }

            var produit = await _contexte.Produits.FindAsync(produitId);
            if (produit == null)
            {
                throw new ArgumentException($"Le produit d’ID={produitId} n’existe pas.");
            }

            var demande = new DemandeReapprovisionnement
            {
                MagasinId = magasinId,
                ProduitId = produitId,
                QuantiteDemandee = quantiteDemande,
                DateDemande = DateTime.UtcNow,
                Statut = "EnAttente"
            };

            _contexte.DemandesReapprovisionnement.Add(demande);
            await _contexte.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<DemandeReapprovisionnement>> GetDemandesReapprovisionnementAsync()
        {
            return await _contexte.DemandesReapprovisionnement
                .Include(d => d.Magasin)
                .Include(d => d.Produit)
                .OrderByDescending(d => d.DateDemande)
                .ToListAsync();
        }
    }
}
