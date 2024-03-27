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
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }   
        public DbSet<Tag> Tags { get; set; }   
        public DbSet<ProductAttributes> Attributes { get; set; }   
    }
}
