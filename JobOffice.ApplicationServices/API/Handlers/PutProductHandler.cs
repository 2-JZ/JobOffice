using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class PutProductHandler: IRequestHandler<PutProductRequest, PutProductResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutProductHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.Id
            };
            var productFromQuery = await this.queryExecutor.Execute(query);
            if (productFromQuery == null)
            {
                return null;
            }
            else
            {
                var mappedProductFromRequest = this.mapper.Map<Product>(request);
                var command = new PutProductCommand() { Parameter = mappedProductFromRequest };
                var productDb = await this.commandExecutor.Execute(command);
                return new PutProductResponse()
                {
                    Data = this.mapper.Map<Domain.Models.Product>(productDb)
                };
            }
        }
    }
}
