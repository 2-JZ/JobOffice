using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdRequest, GetContactByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetContactByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetContactByIdResponse> Handle(GetContactByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetContactByIdQuery()
            {
                Id = request.Id
            };
            var contactFromDb = await this.queryExecutor.Execute(query);

            return new GetContactByIdResponse()
            {
                Data = this.mapper.Map<Contact>(contactFromDb)
            };
        }
    }
}
