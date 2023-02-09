using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoicesQuery();
            var invoicesFromDb =await this.queryExecutor.Execute(query);
            return new GetInvoicesResponse
            {
                Data = this.mapper.Map<List<Invoice>>(invoicesFromDb)
            };
        }
    }
}
