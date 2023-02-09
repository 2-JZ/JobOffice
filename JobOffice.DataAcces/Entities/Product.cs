using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class Product: EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string ProductName { get; set; }
        public decimal? UnitPriceNetto { get; set; }
        public decimal? UnitPriceBrutto { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public float? Discount { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
