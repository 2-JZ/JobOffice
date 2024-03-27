using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace JobOffice.DataAcces.Entities
{
    public class ProductAttributes : EntityBase
    {

        [Required]
        public string Name { get; set; }
    }
}
