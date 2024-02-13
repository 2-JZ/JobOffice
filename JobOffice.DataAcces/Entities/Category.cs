using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string? Description { get; set; }  

        public string? Picture { get; set; }  

        public string? CategoryURL { get; set; }  

        public int? IdSubCategory { get; set; }  

        public bool isActive { get; set; }

        public DateTime CreatedCategoryId { get; set; } = DateTime.Now;

        public ICollection<SubCategory>? SubCategories { get; set; }  
    }
}
