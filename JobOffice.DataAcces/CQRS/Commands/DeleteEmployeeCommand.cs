using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteEmployeeCommand : CommandBase<Employee, Employee>
    {
        public int Id { get; set; }
        public override async Task<Employee> Execute(JobOfficeContext context)
        {
            //var employee = await context.Employees.SingleOrDefaultAsync(x => x.Id == this.Id);
            var employee = await context.Employees.Where(a => a.Id == this.Id).FirstOrDefaultAsync();

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            //return this.Parameter ;
            return this.Parameter ;
        }
    }
}
