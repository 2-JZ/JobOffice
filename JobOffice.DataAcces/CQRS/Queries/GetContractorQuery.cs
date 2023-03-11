using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContractorQuery : QueryBase<JobOffice.DataAcces.Entities.Contractor>
    {
        public int Id { get; set; }
        public async override Task<Contractor> Execute(JobOfficeContext context)
        {
            var contractor = await context.Contractors.FirstOrDefaultAsync(c=>c.Id == this.Id);
            return contractor;
        }
    }
}
