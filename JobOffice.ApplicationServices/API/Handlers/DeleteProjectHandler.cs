using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectRequest, DeleteProjectResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public DeleteProjectHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;

        }
        public async Task<DeleteProjectResponse> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteProjectCommand()
            {
                Id = request.Id,
            };
            var projectFromDb = await this.commandExecutor.Execute(command);

            
            return new DeleteProjectResponse()
            {
                Data = this.mapper.Map<Domain.Models.Project>(projectFromDb)


            };
        }
    }
}
