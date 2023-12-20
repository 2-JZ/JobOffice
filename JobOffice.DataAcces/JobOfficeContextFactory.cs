using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces
{
    public class JobOfficeContextFactory : IDesignTimeDbContextFactory<JobOfficeContext>
    {
        public JobOfficeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JobOfficeContext>();
            optionsBuilder.UseSqlServer("Data Source=TOMEK\\SQLEXPRESS;Initial Catalog=JobOffice;Integrated Security=True;Encrypt=False;TrustServerCertificate=False");
            return new JobOfficeContext(optionsBuilder.Options);
        }
    }
}
