using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteProductHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;

        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "Developer")
            {
                return new DeleteProductResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var isProductInDb = new GetProductQuery()
                {
                    Id = request.Id
                };
                var product = await queryExecutor.Execute(isProductInDb);
                if(product == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteProductCommand()
                    {
                        Id = request.Id,
                    };
                    var productFromDb = await this.commandExecutor.Execute(command);
                    //var response = new DeleteProductResponse();
                    //if(productFromDb == product)
                    //{
                    //    response.Data = true;
                    //}
                    //else
                    //{
                    //    response.Data = false;
                    //}
                    //return response;
                    return new DeleteProductResponse()
                    {
                        Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
                    };
                }

            }
        }
    }
}
