using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var query = new GetContactsQuery();
            var contactsFromDb = await this.queryExecutor.Execute(query);
            return new GetContactsResponse()
            {
                Data = this.mapper.Map<List<Contact>>(contactsFromDb)
            };
            
        }
    }
}
