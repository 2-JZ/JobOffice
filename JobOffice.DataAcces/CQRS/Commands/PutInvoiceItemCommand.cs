using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutInvoiceItemCommand : CommandBase<InvoiceItem, InvoiceItem>
    {
        public override async Task<InvoiceItem> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
