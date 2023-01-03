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
    public class GetContractorsHandler : IRequestHandler<GetContractorsRequest, GetContractorsResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetContractorsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetContractorsResponse> Handle(GetContractorsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetContractorsQuery();
            var contractorsFromDb = await this.queryExecutor.Execute(query);
            return new GetContractorsResponse()
            {
                Data = this.mapper.Map<List<Contractor>>(contractorsFromDb)
            };
        }
    }
}
