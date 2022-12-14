using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class UpdateEmployeeCommand : CommandBase<Employee, Employee>
    {

        public async override Task<Employee> Execute(JobOfficeContext context)
        {
            //var employee = context.Employees.FirstOrDefault(x => x.Id == this.Id);

            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

            //context.Entry(Parameter).State = EntityState.Modified;
            //context.Entry(Parameter).Property(x => x.ContactId).IsModified = false;
            ////context.Employees.Update(Parameter);
            //context.Set<Employee>().Update(Parameter);
            //await context.SaveChangesAsync();
            //return this.Parameter;

            //context.Entry(Parameter).State = EntityState.Detached;
            //context.Set<Employee>().Update(Parameter);
            //await context.SaveChangesAsync();
            //return this.Parameter;
        }
    }
}
