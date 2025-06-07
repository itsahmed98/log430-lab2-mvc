using MagasinCentral.Models;
using MagasinCentral.Data;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Services
{
    /// <summary>
    /// Service pour gérer les opérations liées aux ventes.
    /// </summary>
    public class VenteService : IVenteService
    {
        private readonly MagasinDbContext _contexte;

        public VenteService(MagasinDbContext contexte)
        {
            _contexte = contexte ?? throw new ArgumentNullException(nameof(contexte));
        }

        /// <inheritdoc />
        public async Task EnregistrerVenteAsync(int magasinId, List<(int produitId, int quantite)> lignes)
        {
            if (!lignes.Any()) throw new ArgumentException("Pas de lignes de vente.");
            var now = DateTime.UtcNow;
            foreach (var (pid, qte) in lignes)
            {
                var produit = await _contexte.Produits.FindAsync(pid)
                    ?? throw new ArgumentException($"Produit {pid} inconnu");
                var stockLocal = await _contexte.MagasinStocksProduits
                    .FirstOrDefaultAsync(ms => ms.MagasinId == magasinId && ms.ProduitId == pid);
                if (stockLocal == null || stockLocal.Quantite < qte)
                    throw new InvalidOperationException($"Stock insuffisant pour le produit {pid}");

                stockLocal.Quantite -= qte;

                var vente = new Vente
                {
                    Date = now,
                    MagasinId = magasinId,
                    ProduitId = pid,
                    Quantite = qte,
                    PrixUnitaire = produit.Prix
                };
                _contexte.Ventes.Add(vente);
            }
            await _contexte.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task AnnulerVenteAsync(int venteId)
        {
            var vente = await _contexte.Ventes.FindAsync(venteId)
                ?? throw new ArgumentException("Vente introuvable.");
            // restituer stock local
            var stock = await _contexte.MagasinStocksProduits
                .FirstOrDefaultAsync(ms => ms.MagasinId == vente.MagasinId && ms.ProduitId == vente.ProduitId);
            if (stock != null) stock.Quantite += vente.Quantite;
            // supprimer la vente
            _contexte.Ventes.Remove(vente);
            await _contexte.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<Vente>> GetVentesAsync()
        {
            return await _contexte.Ventes
                .Include(v => v.Magasin)
                .Include(v => v.Produit)
                .OrderByDescending(v => v.Date)
                .ToListAsync();
        }

    }
}