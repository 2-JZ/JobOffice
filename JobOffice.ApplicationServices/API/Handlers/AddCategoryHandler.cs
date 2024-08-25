using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;

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
            // Select Folder For Images
            var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            var uniqueFileName = $"{Guid.NewGuid()}_{request.Image.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Check if exist folder
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // save photo
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.Image.CopyToAsync(fileStream);
            }

            // path for image
            category.ImagePath = $"/images/{uniqueFileName}";
        }

        var command = new AddCategoryCommand() { Parameter = category };
        var categoryFromDb = await this.commandExecutor.Execute(command);

        return new AddCategoryResponse()
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Category>(categoryFromDb)
        };
    }
}
