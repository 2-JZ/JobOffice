using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Contact: EntityBase
    {
        public int Telephone { get; set; }
        public Employee Employees { get; set; }
        public List<Contractor> Contractors { get; set; }

    
    }
}
