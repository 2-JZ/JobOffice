using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public int Id { get; set; }
        public List<string> ContractorNames { get; set; }
        public List<string> EmployeeNames { get; set; }


    }
}
