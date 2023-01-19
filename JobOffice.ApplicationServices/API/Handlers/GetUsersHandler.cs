using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new GetUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetUsersQuery();
                var usersFromDb = await this.queryExecutor.Execute(query);
                return new GetUsersResponse()
                {
                    Data = this.mapper.Map<List<User>>(usersFromDb)
                };
            }
        }
    }
}
