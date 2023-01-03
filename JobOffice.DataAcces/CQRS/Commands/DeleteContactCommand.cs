using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteContactCommand : CommandBase<Contact, Contact>
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
