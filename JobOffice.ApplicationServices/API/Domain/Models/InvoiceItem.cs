
namespace JobOffice.ApplicationServices.API.Domain.Models;

public class InvoiceItem

{
    public int ProductId { get; set; }  // Product ID
    public string ProductName { get; set; }  // Name of the product
    public decimal UnitPrice { get; set; }  // Price per unit
    public decimal Quantity { get; set; }  // Quantity ordered
    public decimal TotalPrice { get; set; }  // Total price for this line item (UnitPrice * Quantity)
    public decimal? Discount { get; set; }  // Any applicable discount
    public string Description { get; set; }  // Additional description of the item
}