using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetInvoiceItemQuery: QueryBase<InvoiceItem>
    {
        public int Id { get; set; }
        public async override Task<InvoiceItem> Execute(JobOfficeContext context)
        {

            var invoiceItem = await context.InvoiceItems.FirstOrDefaultAsync(x => x.Id == this.Id);
            return invoiceItem;

        }
    }
}
