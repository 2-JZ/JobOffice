using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetProjectHandler : IRequestHandler<GetProjectRequest, GetProjectResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetProjectHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProjectResponse> Handle(GetProjectRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProjectQuery()
            {
                Id = request.Id,
            };
            var projectFromDb = await this.queryExecutor.Execute(query);
            if (projectFromDb == null)
            {
                return new GetProjectResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetProjectResponse()
            {
                Data = this.mapper.Map<Project>(projectFromDb)
            };
        }
    }
}
