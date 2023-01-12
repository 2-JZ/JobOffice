using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Project:EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string ProjectName { get; set; }
        public DateTime? ProjectStart { get; set; }
        [Required]
        [MaxLength(2000)]
        [MinLength(3)]
        public string ProjectDescription { get; set; }
        public DateTime? ProjectEnd { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Adress { get; set; }       
        public List<Employee>? Employees { get; set; }
        public List<Contractor>? Contractors { get; set; }


    }
}
