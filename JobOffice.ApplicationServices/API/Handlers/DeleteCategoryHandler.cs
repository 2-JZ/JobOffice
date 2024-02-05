using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        public DeleteCategoryHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;

        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole != "Admin")
            {
                return new DeleteCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var isCategoryInDb = new GetCategoryByIdQuery()
                {
                    Id = request.Id
                };
                var category = await queryExecutor.Execute(isCategoryInDb);
                if (category == null)
                {
                    return new DeleteCategoryResponse
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
                {
                    var command = new DeleteCategoryCommand()
                    {
                        Id = request.Id,
                    };
                    var categoryFromDb = await this.commandExecutor.Execute(command);

                    return new DeleteCategoryResponse()
                    {
                        Data = this.mapper.Map<Category>(categoryFromDb)
                    };
                }
            }
        }
    }
}
