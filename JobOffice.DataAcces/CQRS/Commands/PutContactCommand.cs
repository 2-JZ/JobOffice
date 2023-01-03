using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutContactCommand : CommandBase<Contact, Contact>
    {
        //public int Id { get; set; }
        public async override Task<Contact> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
