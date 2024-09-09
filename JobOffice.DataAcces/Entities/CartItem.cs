using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOffice.DataAcces.Entities
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }  // Primary Key

        public int? CartId { get; set; }  // Foreign Key to ShoppingCart (Nullable)

        public ShoppingCart? ShoppingCart { get; set; }  // Navigation property for the ShoppingCart (Nullable)

        public int? ProductId { get; set; }  // Foreign Key to Product (Nullable)

        [MaxLength(255)]
        public string? ItemName { get; set; }  // Name of the product (Nullable)

        public int? Quantity { get; set; }  // Quantity of the product in the cart (Nullable)

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }  // Price of the product when added to the cart (Nullable)

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }  // Optional discount applied to the product (Nullable)
    }
}
