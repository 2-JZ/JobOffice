using JobOffice.DataAcces.Entities;
using System.ComponentModel.DataAnnotations;
namespace JobOffice.DataAcces.Entities
{

    public class InvoiceItem : EntityBase
    {
        // Foreign key to the related invoice
        public int InvoiceId { get; set; }  // Link to the Invoice
        public Invoice Invoice { get; set; }  // Navigation property for EF Core

        // Product information
        public Product Product { get; set; }  // Navigation property to Product
        [Required]
        public int ProductId { get; set; }  // Link to the Product

        // Transaction details
        [Required]
        public decimal UnitPrice { get; set; }  // Price per unit at time of sale
        [Required]
        public decimal Quantity { get; set; }   // Quantity purchased

        // Discount fields
        public DiscountType DiscountType { get; set; }  // Type of discount (Percentage or Fixed Amount)
        public decimal DiscountValue { get; set; }      // Discount percentage or fixed amount

        // Calculated total price
        public decimal TotalPrice
        {
            get
            {
                // Apply discount based on DiscountType
                return DiscountType == DiscountType.Percentage
                    ? (UnitPrice * Quantity) * (1 - DiscountValue / 100)   // Percentage discount
                    : (UnitPrice * Quantity) - DiscountValue;              // Fixed amount discount
            }
        }

        // Description or additional info about the invoice item
        [StringLength(2000, MinimumLength = 3)]
        public string Description { get; set; }
    }
}