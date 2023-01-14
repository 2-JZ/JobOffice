using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [HttpGet]
        [Route("{productId}")]
        public Task<IActionResult> GetProduct([FromRoute] int productId)
        {
            var request = new GetProductRequest()
            {
                Id = productId
            };
            return this.HandleRequest<GetProductRequest, GetProductResponse>(request);
        }

        [HttpDelete]
        [Route("{productId}")]
        public Task<IActionResult> DeleteInvoice([FromRoute] int productId)
        {
            var request = new DeleteProductRequest()
            {
                Id = productId
            };
            return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> PostProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpPut]
        [Route("{productId}")]
        public Task<IActionResult> PutProduct([FromBody] PutProductRequest request)
        {
            return this.HandleRequest<PutProductRequest, PutProductResponse>(request);
        }
    }
}
