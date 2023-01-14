using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Contact: EntityBase
    {
        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public int Telephone { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string? Skype { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string? WhatsApp { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        public Contractor Contractor { get; set; }
        public int? ContractorId { get; set; }    
    }
}
