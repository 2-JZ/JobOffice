using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
