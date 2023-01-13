using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddInvoiceItemCommand : CommandBase<InvoiceItem, InvoiceItem>
    {
        public override async Task<InvoiceItem> Execute(JobOfficeContext context)
        {
            await context.InvoiceItems.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
