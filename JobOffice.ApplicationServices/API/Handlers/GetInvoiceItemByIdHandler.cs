using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetInvoiceItemByIdHandler: IRequestHandler<GetInvoiceItemRequest, GetInvoiceItemResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetInvoiceItemByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetInvoiceItemResponse> Handle(GetInvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceItemQuery()
            {
                Id = request.Id
            };
            var invoiceItemFromDb = await this.queryExecutor.Execute(query);
            return new GetInvoiceItemResponse
            {
                Data = this.mapper.Map<InvoiceItem>(invoiceItemFromDb)
            };
        }
    }
}
