using AutoMapper;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.CQRS;
using MediatR;
using JobOffice.DataAcces.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
{
    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;
    private readonly IWebHostEnvironment webHostEnvironment;

    public AddCategoryHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IWebHostEnvironment webHostEnvironment)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
        this.webHostEnvironment = webHostEnvironment;
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

        var category = this.mapper.Map<Category>(request);

        if (request.Image != null)
        {
            var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            var uniqueFileName = $"{Guid.NewGuid()}_{request.Image.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.Image.CopyToAsync(fileStream);
            }

            category.ImagePath = uniqueFileName;
        }

        var command = new AddCategoryCommand() { Parameter = category };
        var categoryFromDb = await this.commandExecutor.Execute(command);

        return new AddCategoryResponse()
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Category>(categoryFromDb)
        };
    }
}