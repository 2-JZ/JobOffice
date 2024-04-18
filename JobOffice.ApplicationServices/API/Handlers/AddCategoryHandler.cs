using AutoMapper;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.CQRS;
using MediatR;
using JobOffice.DataAcces.Entities;

public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
{
    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor; 

    public AddCategoryHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
        this.queryExecutor = queryExecutor; 
    }

    public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {


        if (request.AuthenticationRole.ToString() == "Developer")
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