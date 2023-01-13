using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
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
    public class DeleteInvoiceItemHandler : IRequestHandler<DeleteInvoiceItemRequest, DeleteInvoiceItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteInvoiceItemHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }

        public async Task<DeleteInvoiceItemResponse> Handle(DeleteInvoiceItemRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteInvoiceItemCommand()
            {
                Id = request.Id
            };
            //var employee = await this.commandExecutor.Execute(command);
            var invoiceItemFromDb = await this.commandExecutor.Execute(command);
            var result = new DeleteEmployeeCommand(); //{ Parameter = employee };

            return new DeleteInvoiceItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.InvoiceItem>(invoiceItemFromDb)

            };

        }
    }
}
