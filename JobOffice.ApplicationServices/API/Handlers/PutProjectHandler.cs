using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class PutProjectHandler : IRequestHandler<PutProjectRequest, PutProjectResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutProjectHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<PutProjectResponse> Handle(PutProjectRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProjectQuery()
            {
                Id = request.Id
            };
            var projectFromQuery = await this.queryExecutor.Execute(query);
            if (projectFromQuery == null)
            {
                return new PutProjectResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };

            }
            else
            {
                var mappedProjectFromRequest = this.mapper.Map<Project>(request);
                var command = new PutProjectCommand() { Parameter = mappedProjectFromRequest };
                var projectDb = await this.commandExecutor.Execute(command);
                return new PutProjectResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Project>(projectDb)
                };
            }
        }
    }
}
