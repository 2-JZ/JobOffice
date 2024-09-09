using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOffice.DataAcces.Entities
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }  // Primary Key

        public int? UserId { get; set; }  // Foreign Key to the User (Nullable for anonymous users)

        public DateTime? CreatedAt { get; set; } = DateTime.Now;  // Creation timestamp (Nullable)

        [MaxLength(20)]
        public string? Status { get; set; } = "Active";  // Cart status (Nullable, default 'Active')

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }  // Total amount for the shopping cart (Nullable)

        // Navigation property for Cart Items (1-to-Many relationship)
        public List<CartItem> Items { get; set; } = new List<CartItem>();  // List is initialized and no need for nullable
    }
}
