using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class SubCategory : EntityBase
    {
        [MaxLength(50)]
        [MinLength(5)]
        public string SubCategoryDescription { get; set; }
        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Picture { get; set; }
        public string SubCategoryURL { get; set; }
    }
}
