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
        public string ProjectName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Contractor> Contractors { get; set; }


    }
}
