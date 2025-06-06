using System.ComponentModel.DataAnnotations;

namespace MagasinCentral.Models
{
    /// <summary>
    /// Représente le stock central (entrepôt) pour tous les magasins.
    /// Chaque produit y a une quantité globale.
    /// </summary>
    public class StockCentral
    {
        [Key]
        public int ProduitId { get; set; }

        /// <summary>
        /// Quantité totale du produit dans le stock central.
        /// </summary>
        [Required]
        public int Quantite { get; set; }

        /// <summary>
        /// Propriété de navigation vers le produit.
        /// </summary>
        public Produit Produit { get; set; } = null!;
    }
}
