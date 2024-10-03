using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int Number { get; set; }
        public DateTime InvoiceIssue { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public string PaymentMethod { get; set; }  // Can be string for clarity in API

        public decimal TotalAmount { get; set; }
        public bool? IsPaid { get; set; }

        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

    }
}
