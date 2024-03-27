using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOffice.DataAcces.Entities
{
    public class Category : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Klucz obcy dla kategorii nadrzędnej (jeśli istnieje)
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        // Relacja jeden-do-wielu z podkategorią
        public List<Category> Children { get; set; }

        // Lista atrybutów kategorii
        public List<ProductAttributes> Attributes { get; set; }

        // Lista tagów przypisanych do kategorii
        public List<Tag> Tags { get; set; }

    }



}
