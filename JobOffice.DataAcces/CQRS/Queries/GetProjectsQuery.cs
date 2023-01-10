using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetProjectsQuery : QueryBase<List<Project>>
    {
        public override async Task<List<Project>> Execute(JobOfficeContext context)
        {
            var projects = await context.Projects
                .Include(x=>x.Contractors)
                .Include(x=>x.Employees)
                .Where(x => x.ProjectName == "Vien")
                .ToListAsync();
            return projects;
        }
    }
}
