using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteInvoiceItemCommand: CommandBase<InvoiceItem, InvoiceItem>
    {
        public int Id { get; set; }
        public override async Task<InvoiceItem> Execute(JobOfficeContext context)
        {
            var invoiceItem = await context.InvoiceItems.Where(a => a.Id == this.Id).FirstOrDefaultAsync();
            context.InvoiceItems.Remove(invoiceItem);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
