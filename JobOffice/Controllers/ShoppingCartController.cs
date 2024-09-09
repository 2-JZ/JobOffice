using JobOffice.ApplicationServices.API.Domain;
using JobOffice.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/carts")]
public class ShoppingCartController : ApiControllerBase
{
    //private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator, ILogger<CategoryController> logger) : base(mediator)
    {
    }

    //[HttpGet("{cartId}")]
    //public async Task<IActionResult> GetCart([FromRoute] int cartId)
    //{
    //    var response = await _mediator.Send(new GetCartByIdRequest { CartId = cartId });
    //    if (response == null) return NotFound();

    //    return Ok(response.ShoppingCart);
    //}

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


    //[HttpPost("{cartId}/items")]
    //public async Task<IActionResult> AddItemToCart([FromRoute] int cartId, [FromBody] AddItemToCartRequest request)
    //{
    //    request.CartId = cartId;
    //    var response = await _mediator.Send(request);
    //    if (!response.Success) return BadRequest();

    //    return Ok();
    //}

    //[HttpDelete("{cartId}/items/{productId}")]
    //public async Task<IActionResult> RemoveItemFromCart([FromRoute] int cartId, [FromRoute] int productId)
    //{
    //    var response = await _mediator.Send(new RemoveItemFromCartRequest
    //    {
    //        CartId = cartId,
    //        ProductId = productId
    //    });
    //    if (!response.Success) return BadRequest();

    //    return Ok();
    //}
}
