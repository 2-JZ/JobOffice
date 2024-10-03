using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class AddInvoiceHandler : IRequestHandler<AddInvoiceRequest, AddInvoiceResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddInvoiceHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddInvoiceResponse> Handle(AddInvoiceRequest request, CancellationToken cancellationToken)
        {
            // Map the incoming request to the Invoice entity
            var invoice = this.mapper.Map<JobOffice.DataAcces.Entities.Invoice>(request);

            // Calculate Total Amount based on items in the request
            invoice.TotalAmount = request.Items.Sum(item => item.TotalPrice);

            // Map invoice items to their corresponding entities
            var invoiceItems = this.mapper.Map<List<DataAcces.Entities.InvoiceItem>>(request.Items);
            invoice.Items = invoiceItems;

            // Create the command to add the invoice
            var command = new AddInvoiceCommand() { Parameter = invoice };
            var invoiceFromDb = await this.commandExecutor.Execute(command);

            return new AddInvoiceResponse()
            {
                Data = this.mapper.Map<Domain.Models.Invoice>(invoiceFromDb),
            };
        }
    }
}
