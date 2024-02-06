using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddCategoryHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;

        }
        public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() != "Admin")
            {
                return new AddCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var category = this.mapper.Map<Category>(request);
                var command = new AddCategoryCommand() { Parameter = category };
                var categoryFromDb = await this.commandExecutor.Execute(command);

                return new AddCategoryResponse()
                {
                    Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Category>(categoryFromDb)
                };
            }


        }
    }
}
