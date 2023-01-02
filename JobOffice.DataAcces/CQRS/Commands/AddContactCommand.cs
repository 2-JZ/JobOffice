using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddContactCommand : CommandBase<Contact, Contact>
    {
        public override async Task<Contact> Execute(JobOfficeContext context)
        {
            await context.Contacts.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;


        }
    }
}
