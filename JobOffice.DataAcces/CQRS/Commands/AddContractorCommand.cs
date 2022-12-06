using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
