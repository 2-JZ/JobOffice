using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutContactCommand : CommandBase<Contact, Contact>
    {
        public async override Task<Contact> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
