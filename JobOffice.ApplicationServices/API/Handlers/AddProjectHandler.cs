using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class AddProjectHandler : IRequestHandler<AddProjectRequest, AddProjectResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        public AddProjectHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;

        }

        public async Task<AddProjectResponse> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            var project = this.mapper.Map<Project>(request);
            var command = new AddProjectCommand() { Parameter = project };
            var projectFromDb = await this.commandExecutor.Execute(command);
            return new AddProjectResponse()
            {
                Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Project>(project),
            };
        }
    }
}
