﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Employee: EntityBase
    {
        
        public string? Surname { get; set; }
        public int ContactID { get; set; }
    }
}
