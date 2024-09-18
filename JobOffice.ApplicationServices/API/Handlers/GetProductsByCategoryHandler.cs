using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryRequest, GetProductsByCategoryResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetProductsByCategoryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsByCategoryQuery
            {
                CategoryId = request.CategoryId
            };
            var productsFromDb = await this.queryExecutor.Execute(query);
            if (productsFromDb == null || !productsFromDb.Any())
            {
                return new GetProductsByCategoryResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProducts = this.mapper.Map<List<Product>>(productsFromDb);
            return new GetProductsByCategoryResponse
            {
                Data = mappedProducts
            };
        }
    }
}
