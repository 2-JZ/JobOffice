using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddInvoiceItemRequest : RequestBase, IRequest<AddInvoiceItemResponse>
    {
        // The ID of the invoice this item belongs to
        public int InvoiceId { get; set; }

        // Product Information
        public int ProductId { get; set; }  // Product ID
        public string ProductName { get; set; }  // Name of the product

        // Pricing and Quantity Information
        public decimal UnitPrice { get; set; }  // Price per unit at time of sale
        public decimal Quantity { get; set; }  // Quantity ordered
        public decimal TotalPrice { get; set; }  // Total price for this line item (UnitPrice * Quantity)

        // Discount Information
        public decimal? Discount { get; set; }  // Any applicable discount

        // Additional Information
        public string Description { get; set; }  // Additional description of the item
    }
}
