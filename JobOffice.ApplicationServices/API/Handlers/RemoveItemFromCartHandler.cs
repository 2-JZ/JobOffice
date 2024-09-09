using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS;
using MediatR;

public class RemoveItemFromCartHandler : IRequestHandler<RemoveItemFromCartRequest, RemoveItemFromCartResponse>
{
    private readonly ICommandExecutor commandExecutor;

    public RemoveItemFromCartHandler(ICommandExecutor commandExecutor)
    {
        this.commandExecutor = commandExecutor;
    }

    public async Task<RemoveItemFromCartResponse> Handle(RemoveItemFromCartRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveCartItemCommand { CartId = request.CartId, ProductId = request.ProductId };
        await this.commandExecutor.Execute(command);

        return new RemoveItemFromCartResponse();
    }
}
