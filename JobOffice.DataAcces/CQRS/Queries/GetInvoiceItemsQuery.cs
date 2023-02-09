using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetInvoiceItemsQuery: QueryBase<List<InvoiceItem>>
    {
        public override Task<List<InvoiceItem>> Execute(JobOfficeContext context)
        {
            return context.InvoiceItems.ToListAsync();

        }
    }
}
