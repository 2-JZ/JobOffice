using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class SubCategory : EntityBase
    {
        [MaxLength(50)]
        [MinLength(5)]
        public string? SubCategoryDescription { get; set; }  // SubCategoryDescription jako nullable

        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string SubCategoryName { get; set; }  // SubCategoryName jako nullable, ale oznaczone jako wymagane

        public int? CategoryId { get; set; }  // CategoryId jako nullable

        public Category? Category { get; set; }  // Category jako nullable

        public string? Picture { get; set; }  // Picture jako nullable

        public string? SubCategoryURL { get; set; }  // SubCategoryURL jako nullable
    }
}
