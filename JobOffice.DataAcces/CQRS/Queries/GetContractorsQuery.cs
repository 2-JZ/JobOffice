using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContractorsQuery : QueryBase<List<Contractor>>
    {
        public override async Task<List<Contractor>> Execute(JobOfficeContext context)
        {
            var contractors = await context.Contractors
                .Include(x=>x.Contacts)
                .ToListAsync();
            return contractors;
        }
    }
}
