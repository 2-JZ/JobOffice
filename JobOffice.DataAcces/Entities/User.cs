using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class User : EntityBase
    {
        [MaxLength(50)]
        public string FirstName { get; set; }        
        [MaxLength(50)]
        public string LastName { get; set; }
        [MinLength(3)]
        public string Username { get; set; }
        [MinLength(3)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public Role Role { get; set; }
    }
}
