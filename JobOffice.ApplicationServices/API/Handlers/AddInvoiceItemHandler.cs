using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class AddInvoiceItemHandler : IRequestHandler<AddInvoiceItemRequest, AddInvoiceItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public AddInvoiceItemHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }
        public async Task<AddInvoiceItemResponse> Handle(AddInvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var invoiceItem = this.mapper.Map<DataAcces.Entities.InvoiceItem>(request);
            var command = new AddInvoiceItemCommand() { Parameter = invoiceItem };
            var invoiceItemFromDb = await this.commandExecutor.Execute(command);

            return new AddInvoiceItemResponse()
            {
                Data = this.mapper.Map<InvoiceItem>(invoiceItemFromDb),
            };
        }
    }
}
