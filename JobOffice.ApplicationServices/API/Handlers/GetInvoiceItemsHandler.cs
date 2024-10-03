using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetInvoiceItemsHandler : IRequestHandler<GetInvoiceItemsRequest, GetInvoiceItemsResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetInvoiceItemsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetInvoiceItemsResponse> Handle(GetInvoiceItemsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceItemsQuery();
            var invoiceItemsFromDb = await this.queryExecutor.Execute(query);
            return new GetInvoiceItemsResponse()
            {
                Data = this.mapper.Map<List<JobOffice.ApplicationServices.API.Domain.Models.InvoiceItem>>(invoiceItemsFromDb)
            };
        }
    }
}
