using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetCategoriesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new GetCategoriesResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetCategoriesQuery();
                var categoriesFromDb = await this.queryExecutor.Execute(query);
                return new GetCategoriesResponse()
                {
                    Data = this.mapper.Map<List<Category>>(categoriesFromDb)
                };
            }
        }
    }
}
