using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteInvoiceHandler: IRequestHandler<DeleteInvoiceRequest, DeleteInvoiceResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        public DeleteInvoiceHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }

        public async Task<DeleteInvoiceResponse> Handle(DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteInvoiceCommand()
            {
                Id = request.Id
            };
            //var employee = await this.commandExecutor.Execute(command);
            var invoiceDeletedFromDb = await this.commandExecutor.Execute(command);
            var result = new DeleteInvoiceCommand(); //{ Parameter = employee };

            return new DeleteInvoiceResponse()
            {
                Data = this.mapper.Map<Domain.Models.Invoice>(invoiceDeletedFromDb)

            };
        }
    }
}
