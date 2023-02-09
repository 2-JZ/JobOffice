using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        public async override Task<List<Invoice>> Execute(JobOfficeContext context)
        {
            var invoices = await context.Invoice.ToListAsync();
            return invoices;

        }
    }
}
