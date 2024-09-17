using JobOffice.ApplicationServices.API.Domain;
using JobOffice.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ApiControllerBase
{
    //private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator, ILogger<CategoryController> logger) : base(mediator)
    {
    }

    [HttpPost]
    [Route("CreateCart")]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request)
    {
        var createCartRequest = new CreateCartRequest
        {
            UserId = request.UserId // UserId is nullable (null for anonymous users)
        };

        return await this.HandleRequest<CreateCartRequest, CreateCartResponse>(createCartRequest);
    }

    [HttpGet]
    [Route("{categoryId}")]
    public Task<IActionResult> GetCart([FromRoute] int cartId)
    {
        var request = new GetCartByIdRequest()
        {
            CartId = cartId
        };
        return this.HandleRequest<GetCartByIdRequest, GetCartByIdResponse>(request);

    }

    [HttpPost]
    [Route("{cartId}/items")]
    public Task<IActionResult> AddItemToCart([FromRoute]int cartId,[FromBody] AddItemToCartRequest request)
    {
        request.CartId = cartId;
        return this.HandleRequest<AddItemToCartRequest, AddItemToCartResponse>(request);
    }
 
    [HttpDelete]
    [Route("{cartId}/items/{productId}")]
    public async Task<IActionResult> RemoveItemFromCart([FromRoute] int cartId, [FromRoute] int productId)
    {
        var request = new RemoveItemFromCartRequest()
        {
            CartId = cartId,
            ProductId = productId
        };
        return await this.HandleRequest<RemoveItemFromCartRequest, RemoveItemFromCartResponse>(request);
    }
}
