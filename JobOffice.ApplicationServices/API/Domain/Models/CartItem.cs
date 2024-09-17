using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class CartItem
    {
        
        public int CartItemId { get; set; }  // Primary Key

        public int? CartId { get; set; }  // Foreign Key to ShoppingCart (Nullable)

        public ShoppingCart? ShoppingCart { get; set; }  // Navigation property for the ShoppingCart (Nullable)

        public int? ProductId { get; set; }  // Foreign Key to Product (Nullable)

        public string? ItemName { get; set; }  // Name of the product (Nullable)

        public int? Quantity { get; set; }  // Quantity of the product in the cart (Nullable)

        public decimal? Price { get; set; }  // Price of the product when added to the cart (Nullable)

        public decimal? Discount { get; set; }  // Optional discount applied to the product (Nullable)
    }
}