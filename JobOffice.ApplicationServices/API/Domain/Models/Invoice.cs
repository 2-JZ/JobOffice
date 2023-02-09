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
        public int EmployeeId { get; set; }
        public int? ContractorId { get; set; }
        public int Number { get; set; }
        public DateTime InvoiceIssue { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public string? PaymentMethod { get; set; }
        public bool? IsActive { get; set; }
    }
}
