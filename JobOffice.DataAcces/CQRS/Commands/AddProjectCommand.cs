using JobOffice.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddProjectCommand : CommandBase<Project, Project>
    {
        public override async Task<Project> Execute(JobOfficeContext context)
        {
            await context.Projects.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}

