using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string CategoryURL { get; set;}
        public int IdSubCategory { get; set; }
        public bool isActive { get; set;}
        public DateTime CategoryCategoryId { get; set;} = DateTime.Now;
        public int CategoryCategoryNameId { get;}

    }
}
