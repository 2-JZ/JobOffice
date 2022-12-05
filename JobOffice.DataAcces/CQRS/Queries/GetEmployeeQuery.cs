using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int Id { get; set; }
        public override async Task<Employee> Execute(JobOfficeContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x=>x.Id == this.Id);
            return employee;
        }
    }
}
