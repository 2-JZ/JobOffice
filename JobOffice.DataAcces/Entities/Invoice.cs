using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Invoice : EntityBase
    {
        public Employee Employee { get; set; }
        [Required]       
        public int EmployeeId { get; set; }
        public Contractor Contractor { get; set; }
        public int? ContractorId { get; set; }
        [Required]
        public int Number { get; set; }
        public DateTime InvoiceIssue { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public string? PaymentMethod { get; set; }
        public bool? IsActive { get; set; }
    }
}
