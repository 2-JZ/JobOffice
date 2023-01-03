using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteContractorCommand : CommandBase<Contractor, Contractor>
    {
        public int Id { get; set; }
        public override async Task<Contractor> Execute(JobOfficeContext context)
        {
            var contractor = await context.Contractors.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
            context.Contractors.Remove(contractor);
            await context.SaveChangesAsync();
            return this.Parameter; 
        }
    }
}
