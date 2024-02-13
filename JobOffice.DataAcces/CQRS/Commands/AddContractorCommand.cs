using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddContractorCommand : CommandBase<Contractor, Contractor>
    {
        public override async Task<Contractor> Execute(JobOfficeContext context)
        {
            await context.Contractors.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
