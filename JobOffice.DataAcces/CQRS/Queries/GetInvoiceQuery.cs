using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetInvoiceQuery: QueryBase<Invoice>
    {
        public int Id { get; set; }
        public async override Task<Invoice> Execute(JobOfficeContext context)
        {

            var invoice = await context.Invoice.FirstOrDefaultAsync(x=>x.Id==this.Id);
            return invoice;

        }
    }
}
