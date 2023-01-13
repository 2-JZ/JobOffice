using AutoMapper;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class InvoiceItem: Profile
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Decimal UnitPrice { get; set; }
        public float Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        public float? Discount { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
    }
}
