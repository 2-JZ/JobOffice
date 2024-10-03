using JobOffice.DataAcces.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Invoice : EntityBase
    {
        // Customer Information
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        // Invoice Details
        [Required]
        public int Number { get; set; } // Invoice number
        [Required]
        public DateTime InvoiceIssue { get; set; } = DateTime.Now; // Date of issue
        [Required]
        public DateTime PaymentDeadline { get; set; } // Deadline for payment
        [Required]
        public string PaymentMethod { get; set; } // e.g., "Bank Transfer", "PayPal", etc.
        [Required]
        public string BankAccountDetails { get; set; } // Where to send the payment

        // List of Items (Products) in the invoice
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        // Calculated total amount
        [Required]
        public decimal TotalAmount { get; set; }

        // Optionally, a status to know if payment was completed
        public bool? IsPaid { get; set; }
    }
}