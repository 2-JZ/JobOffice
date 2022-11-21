using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Employee: EntityBase
    {   
        [Required]
        public string? Name { get; set; }
        
        [MaxLength(100)]
        public string? Surname { get; set; }
        
        public int? ContactID { get; set; }
    }
}
