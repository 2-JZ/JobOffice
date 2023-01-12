﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.Entities
{
    public class Employee : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public List<Invoice>? Invoice { get; set; } = new List<Invoice>();
        public Contact Contact { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Password { get; set; }
        public Role Role { get; set; }

        public string? ZipCode {get;set;}
        public string? City {get;set;}
        public string? Adress {get;set;}
        public Project Project { get; set; }
        public int? ProjectId { get; set; }


        //public Project Project { get; set; }
        //public List<Contact> Contacts { get; set; }
        

    }
}
