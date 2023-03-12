using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContactByIdQuery : QueryBase<Contact>
    {
        public int Id { get; set; }
        public async override Task<Contact> Execute(JobOfficeContext context)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(c=>c.Id == this.Id);
            return contact;
        }
    }
}
