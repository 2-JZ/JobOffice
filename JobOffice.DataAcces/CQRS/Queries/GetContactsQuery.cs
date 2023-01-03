using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContactsQuery : QueryBase<List<Contact>>
    {
        public async override Task<List<Contact>> Execute(JobOfficeContext context)
        {
            var contacts = await context.Contacts.ToListAsync();
            return contacts;
        }
    }
}
