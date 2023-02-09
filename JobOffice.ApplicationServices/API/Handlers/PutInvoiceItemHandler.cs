using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class PutInvoiceItemHandler : IRequestHandler<PutInvoiceItemRequest, PutInvoiceItemResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutInvoiceItemHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<PutInvoiceItemResponse> Handle(PutInvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceItemQuery()
            {
                Id = request.Id
            };
            var invoiceFromQuery = await this.queryExecutor.Execute(query);
            if (invoiceFromQuery == null)
            {
                return new PutInvoiceItemResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            else
            {
                var mappedInvoiceItemFromRequest = this.mapper.Map<InvoiceItem>(request);
                var command = new PutInvoiceItemCommand() { Parameter = mappedInvoiceItemFromRequest };
                var invoiceItemDb = await this.commandExecutor.Execute(command);
                return new PutInvoiceItemResponse()
                {
                    Data = this.mapper.Map<Domain.Models.InvoiceItem>(invoiceItemDb)
                };
            }
        }
    }
}
