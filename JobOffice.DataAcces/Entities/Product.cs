using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
