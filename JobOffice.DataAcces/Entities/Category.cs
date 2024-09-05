using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOffice.DataAcces.Entities
{
    public class Category : EntityBase
    {

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Foreign key to following higher category, if exists
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        public List<ProductAttributes>? Attributes { get; set; }

        public List<Tag>? Tags { get; set; }

        // Field for ordering children
        public int? Order { get; set; }

        // Path to the image file (optional, in case you still want to support file paths)
        public string? ImagePath { get; set; }

        // New property to store the image data directly in the database
        public byte[]? ImageData { get; set; }
    }
}
