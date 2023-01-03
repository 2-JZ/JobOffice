using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetContractorsQuery : QueryBase<List<Contractor>>
    {
        public override async Task<List<Contractor>> Execute(JobOfficeContext context)
        {
            var contractors = await context.Contractors.ToListAsync();
            return contractors;
            throw new NotImplementedException();
        }
    }
}
