using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS;
using MediatR;
using JobOffice.DataAcces.Entities;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartRequest, AddItemToCartResponse>
{
    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;

    public AddItemToCartHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
    }

    public async Task<AddItemToCartResponse> Handle(AddItemToCartRequest request, CancellationToken cancellationToken)
    {
        var cartItem = new CartItem
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Price,
            Discount = request.Discount
        };

        var command = new AddCartItemCommand { Parameter = cartItem, CartId = request.CartId };
        var addedItem = await this.commandExecutor.Execute(command);

        return new AddItemToCartResponse
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.CartItem>(addedItem)
        };
    }
}
