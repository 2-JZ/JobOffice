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
    public class PutInvoiceHandler : IRequestHandler<PutInvoiceRequest, PutInvoiceResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutInvoiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<PutInvoiceResponse> Handle(PutInvoiceRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };
            var invoiceFromQuery = await this.queryExecutor.Execute(query);
            if (invoiceFromQuery == null)
            {
                return new PutInvoiceResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            else
            {
                var mappedInvoiceFromRequest = this.mapper.Map<Invoice>(request);
                var command = new PutInvoiceCommand() { Parameter = mappedInvoiceFromRequest };
                var invoiceDb = await this.commandExecutor.Execute(command);
                return new PutInvoiceResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Invoice>(invoiceDb)
                };
            }
        }
    }
}
