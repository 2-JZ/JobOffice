using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetContactsHandler : IRequestHandler<GetContactsRequest, GetContactsResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetContactsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetContactsResponse> Handle(GetContactsRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new GetContactsResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetContactsQuery();
                var contactsFromDb = await this.queryExecutor.Execute(query);
                return new GetContactsResponse()
                {
                    Data = this.mapper.Map<List<Contact>>(contactsFromDb)
                };
            }
        }
    }
}
