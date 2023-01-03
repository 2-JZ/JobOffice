using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContractorQuery : QueryBase<JobOffice.DataAcces.Entities.Contractor>
    {
        public int Id { get; set; }
        public override async Task<Contractor> Execute(JobOfficeContext context)
        {
            var contractor = await context.Contractors.FirstOrDefaultAsync(c=>c.Id == this.Id);
            return contractor;
        }
    }
}
