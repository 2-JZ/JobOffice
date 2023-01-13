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
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            request = new GetProductsRequest();
            return await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);

        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProduct([FromRoute] int productId)
        {
            var request = new GetProductRequest()
            {
                Id = productId
            };
            return await this.HandleRequest<GetProductRequest, GetProductResponse>(request);

        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int productId)
        {
            var request = new DeleteProductRequest()
            {
                Id = productId
            };
            return await this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostProduct([FromBody] AddProductRequest request)
        {
            return await this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> PutProduct([FromBody] PutProductRequest request)
        {
            return await this.HandleRequest<PutProductRequest, PutProductResponse>(request);

        }
    }
}
