using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Tag : EntityBase
    {

        [Required]
        public string TagName { get; set; }
    }
}
