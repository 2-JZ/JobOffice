using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using MediatR;
using Category = JobOffice.DataAcces.Entities.Category;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class PutCategoryHandler : IRequestHandler<PutCategoryRequest, PutCategoryResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutCategoryHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<PutCategoryResponse> Handle(PutCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() != "Admin")
            {
                return new PutCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetCategoryByIdQuery()
                {
                    Id = request.Id
                };
                var categoryFromQuery = await this.queryExecutor.Execute(query);
                if (categoryFromQuery == null)
                {
                    return new PutCategoryResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
                {
                    var mappedCategoryFromRequest = this.mapper.Map<Category>(request);
                    var command = new PutCategoryCommand()
                    {
                        Parameter = mappedCategoryFromRequest
                    };
                    var categoryDb = await this.commandExecutor.Execute(command);
                    return new PutCategoryResponse()
                    {
                        Data = this.mapper.Map<Domain.Models.Category>(categoryDb)
                    };
                }
            }
        }
    }
}
