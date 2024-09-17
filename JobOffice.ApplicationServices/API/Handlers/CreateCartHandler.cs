using AutoMapper;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS;
using MediatR;
using JobOffice.DataAcces.Entities;

public class CreateCartHandler : IRequestHandler<CreateCartRequest, CreateCartResponse>
{
    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;
    private readonly IQueryExecutor queryExecutor;

    public CreateCartHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
        this.queryExecutor = queryExecutor;
    }

    public async Task<CreateCartResponse> Handle(CreateCartRequest request, CancellationToken cancellationToken)
    {
        // Check if the request is authorized, if needed
        // Example: if (request.AuthenticationRole.ToString() == "Developer") { ... }

        // Create a new ShoppingCart entity
        var shoppingCart = new ShoppingCart
        {
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
            Status = "Active",
            TotalAmount = 0 // Default value
        };

        // Prepare the command to save the new ShoppingCart to the database
        var command = new CreateCartCommand() { Parameter = shoppingCart };
        var shoppingCartFromDb = await this.commandExecutor.Execute(command);

        // Map the entity to a response model
        return new CreateCartResponse
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.ShoppingCart>(shoppingCartFromDb)
        };
    }
}
