using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public int Id { get; set; }
        public override async Task<Invoice> Execute(JobOfficeContext context)
        {
            var invoice = await context.Invoice.Where(a => a.Id == this.Id).FirstOrDefaultAsync();
            context.Invoice.Remove(invoice);
            await context.SaveChangesAsync();
            //return this.Parameter ;
            return this.Parameter;


        }
    }
}
