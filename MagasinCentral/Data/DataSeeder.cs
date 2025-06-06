using System;
using System.Collections.Generic;
using MagasinCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace MagasinCentral.Data
{
    /// <summary>
    /// Fournit des données initiales pour la base de données.
    /// </summary>
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Produits
            var produits = new List<Produit>
            {
                new Produit { ProduitId = 1, Nom = "Stylo",       Categorie = "Papeterie",   Prix = 1.50m },
                new Produit { ProduitId = 2, Nom = "Carnet",      Categorie = "Papeterie",   Prix = 3.75m },
                new Produit { ProduitId = 3, Nom = "Clé USB 16Go", Categorie = "Électronique", Prix = 12.00m },
                new Produit { ProduitId = 4, Nom = "Casque Audio", Categorie = "Électronique", Prix = 45.00m }
            };
            modelBuilder.Entity<Produit>().HasData(produits);

            // Magasins
            var magasins = new List<Magasin>
            {
                new Magasin { MagasinId = 1, Nom = "Magasin Centre-Ville", Adresse = "10 Rue Principale" },
                new Magasin { MagasinId = 2, Nom = "Magasin Université",    Adresse = "5 Avenue des Étudiants" },
                new Magasin { MagasinId = 3, Nom = "Magasin Quartier Nord", Adresse = "23 Boulevard Nord" },
                new Magasin { MagasinId = 4, Nom = "Magasin Sud-Ouest",     Adresse = "42 Rue du Commerce" }
            };
            modelBuilder.Entity<Magasin>().HasData(magasins);

            // 3. Initialiser le stock local pour chaque magasin
            var stockLocaux = new List<MagasinStockProduit>();
            foreach (var magasin in magasins)
            {
                foreach (var produit in produits)
                {
                    stockLocaux.Add(new MagasinStockProduit
                    {
                        MagasinId = magasin.MagasinId,
                        ProduitId = produit.ProduitId,
                        Quantite = 50
                    });
                }
            }
            modelBuilder.Entity<MagasinStockProduit>().HasData(stockLocaux);

            // Initialiser le stock central
            var stocksCentraux = new List<StockCentral>();
            foreach (var produit in produits)
            {
                stocksCentraux.Add(new StockCentral
                {
                    ProduitId = produit.ProduitId,
                    Quantite = 200
                });
            }
            modelBuilder.Entity<StockCentral>().HasData(stocksCentraux);

            // Ventes
            var ventes = new List<Vente>
            {
                new Vente
                {
                    VenteId      = 1,
                    Date         = DateTime.UtcNow.AddDays(-2),
                    MagasinId    = 1,
                    ProduitId    = 1,
                    Quantite     = 10,
                    PrixUnitaire = 1.50m
                },
                new Vente
                {
                    VenteId      = 2,
                    Date         = DateTime.UtcNow.AddDays(-1),
                    MagasinId    = 2,
                    ProduitId    = 3,
                    Quantite     = 5,
                    PrixUnitaire = 12.00m
                },
                new Vente
                {
                    VenteId      = 3,
                    Date         = DateTime.UtcNow.AddDays(-1),
                    MagasinId    = 1,
                    ProduitId    = 2,
                    Quantite     = 7,
                    PrixUnitaire = 3.75m
                },
                new Vente
                {
                    VenteId      = 4,
                    Date         = DateTime.UtcNow,
                    MagasinId    = 3,
                    ProduitId    = 4,
                    Quantite     = 2,
                    PrixUnitaire = 45.00m
                }
            };
            modelBuilder.Entity<Vente>().HasData(ventes);
        }
    }
}
