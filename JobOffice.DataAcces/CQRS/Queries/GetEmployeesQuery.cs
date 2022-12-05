using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetEmployeesQuery:QueryBase<List<Employee>>
    {
        public int Id { get; set; }
        public override Task<List<Employee>> Execute(JobOfficeContext context)
        {
            return context.Employees.ToListAsync();
            
        }
    }
}
