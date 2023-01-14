using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class InvoiceItem : EntityBase
    {
        public Invoice Invoice { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public Decimal UnitPrice { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public float Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public float? Discount { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        [Required]
        [MaxLength(2000)]
        [MinLength(3)]
        public string? Description { get; set; }
    }
}
