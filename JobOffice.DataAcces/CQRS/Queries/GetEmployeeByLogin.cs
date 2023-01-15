using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetEmployeeByLoginQuery : QueryBase<Employee>
    {
        public string Login { get; set; }
        public override async Task<Employee> Execute(JobOfficeContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Login == this.Login);
            return employee;
        }
    }
}
