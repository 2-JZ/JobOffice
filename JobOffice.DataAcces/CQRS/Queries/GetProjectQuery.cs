using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetProjectQuery : QueryBase<Project>
    {
        public int Id { get; set; }
        public override async Task<Project> Execute(JobOfficeContext context)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == this.Id);
            return project;
        }
    }
}
