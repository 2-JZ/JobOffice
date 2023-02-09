using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var invoice = this.mapper.Map<DataAcces.Entities.Invoice>(request);
            var command = new AddInvoiceCommand() { Parameter = invoice };
            var invoiceFromDb = await this.commandExecutor.Execute(command);

            return new AddInvoiceResponse()
            {
                Data = this.mapper.Map<Invoice>(invoiceFromDb),
            };
        }
    }
}
