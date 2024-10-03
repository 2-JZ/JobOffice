using JobOffice.ApplicationServices.API.Domain.Models;
using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutInvoiceRequest : IRequest<PutInvoiceResponse>
    {
        public int Id { get; set; }
        // Customer Information
        public string CustomerName { get; set; } // Name of the customer
        public string CustomerEmail { get; set; } // Email of the customer

        // Invoice Details
        public int Number { get; set; } // Invoice number
        public DateTime InvoiceIssue { get; set; } = DateTime.Now; // Date of issue
        public DateTime PaymentDeadline { get; set; } // Payment deadline
        public string PaymentMethod { get; set; } // Payment method (e.g., Bank Transfer, PayPal)
        public string BankAccountDetails { get; set; } // Where the payment should be sent

        // List of invoice items
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        // Total amount and status
        public decimal TotalAmount { get; set; } // Calculated total amount
        public bool? IsPaid { get; set; } // Optional status to know if the invoice has been paid
    }
}
