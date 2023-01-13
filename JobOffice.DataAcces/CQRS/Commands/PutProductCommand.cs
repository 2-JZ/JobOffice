using JobOffice.DataAcces.Entities;


namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
