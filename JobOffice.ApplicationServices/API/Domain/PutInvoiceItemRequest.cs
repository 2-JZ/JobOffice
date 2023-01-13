using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutInvoiceItemRequest: IRequest<PutInvoiceItemResponse>
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
