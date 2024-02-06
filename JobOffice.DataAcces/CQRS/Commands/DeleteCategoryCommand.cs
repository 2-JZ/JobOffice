using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteCategoryCommand : CommandBase<Category, Category>
    {
        public int Id { get; set; }
        public override async Task<Contact> Execute(JobOfficeContext context)
        {
            var contact = await context.Contacts.Where(a => a.Id == this.Id).FirstOrDefaultAsync();
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}