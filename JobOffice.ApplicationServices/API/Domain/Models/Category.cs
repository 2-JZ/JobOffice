using JobOffice.DataAcces.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Category
    {

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public string? CategoryURL { get; set; }

        public int? IdSubCategory { get; set; }

        public bool isActive { get; set; }

        public DateTime CreatedCategoryId { get; set; } = DateTime.Now;

        public ICollection<SubCategory>? SubCategories { get; set; }

    }
}
