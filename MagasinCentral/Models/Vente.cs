using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagasinCentral.Models
{
    /// <summary>
    ///     Représente une vente réalisée dans un magasin.
    /// </summary>
    public class Vente
    {
        [Key]
        public int VenteId { get; set; }

        /// <summary>
        /// Date et heure de la vente.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Clé étrangère vers le magasin.
        /// </summary>
        [Required]
        public int MagasinId { get; set; }

        /// <summary>
        /// Clé étrangère vers le produit.
        /// </summary>
        [Required]
        public int ProduitId { get; set; }

        /// <summary>
        /// Quantité vendue.
        /// </summary>
        [Required]
        public int Quantite { get; set; }

        /// <summary>
        /// Prix unitaire appliqué lors de la vente.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrixUnitaire { get; set; }

        /// <summary>
        /// Propriété de navigation vers le magasin.
        /// </summary>
        public Magasin Magasin { get; set; } = null!;

        /// <summary>
        /// Propriété de navigation vers le produit.
        /// </summary>
        public Produit Produit { get; set; } = null!;
    }
}
