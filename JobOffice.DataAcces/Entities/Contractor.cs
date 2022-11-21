using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Contractor: EntityBase
    {
        public string Name { get; set; }
        public Contact Contacts { get; set; }
        public int ContactId { get; set; }
        public List <Project> Projects { get; set; }







    }
}
