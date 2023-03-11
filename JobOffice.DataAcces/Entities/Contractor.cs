using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Contractor: EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(10)]
        [MinLength(1)]
        public string? Code { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string? NIP { get; set; }
        //[Required]
        public bool? IsActive { get; set; }
        [MaxLength(100)]
        public string? country { get; set; }
        public List<Project>? Projects { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
