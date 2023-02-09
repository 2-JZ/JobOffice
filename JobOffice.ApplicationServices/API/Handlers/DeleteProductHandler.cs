using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand()
            {
                Id = request.Id
            };
            var productFromDb = await this.commandExecutor.Execute(command);
            var result = new DeleteEmployeeCommand(); 
            return new DeleteProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
            };

        }
    }
}
