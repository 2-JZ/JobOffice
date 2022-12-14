using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces
{
    public class JobOfficeContext : DbContext
    {
        public JobOfficeContext(DbContextOptions<JobOfficeContext> opt) : base(opt)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
    }
}
