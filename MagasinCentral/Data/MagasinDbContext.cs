using MagasinCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Data
{
    /// <summary>
    /// Contexte EF Core pour MagasinCentral.
    /// </summary>
    public class MagasinDbContext : DbContext
    {
        public MagasinDbContext(DbContextOptions<MagasinDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Table des magasins.
        /// </summary>
        public DbSet<Magasin> Magasins { get; set; } = null!;

        /// <summary>
        /// Table des produits.
        /// </summary>
        public DbSet<Produit> Produits { get; set; } = null!;

        /// <summary>
        /// Table des stocks locaux.
        /// </summary>
        public DbSet<MagasinStockProduit> MagasinStocksProduits { get; set; } = null!;

        /// <summary>
        /// Table du stock central (represent un entrepôt).
        /// </summary>
        public DbSet<StockCentral> StocksCentraux { get; set; } = null!;

        /// <summary>
        /// Table des ventes.
        /// </summary>
        public DbSet<Vente> Ventes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MagasinStockProduit>()
                .HasKey(ms => new { ms.MagasinId, ms.ProduitId });

            // Appeler le DataSeeder pour pré-remplir les tables et la base de données.
            DataSeeder.Seed(modelBuilder);
        }
    }
}
