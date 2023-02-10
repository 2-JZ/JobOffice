using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.Id
            };
            var user = await this.queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedEmployee = this.mapper.Map<Domain.Models.User>(user);
            var response = new GetUserResponse()
            {
                Data = mappedEmployee
            };
            return response;
        }
    }
}
