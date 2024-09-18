using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator)
        {
        }

        [HttpGet]
        [Route("byCategory/{categoryId}")]
        public Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
        {
            var request = new GetProductsByCategoryRequest
            {
                CategoryId = categoryId
            };
            return this.HandleRequest<GetProductsByCategoryRequest, GetProductsByCategoryResponse>(request);
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
        public Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductRequest()
            {
                Id = productId
            };
            return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);
        }

        [HttpPost]
        [Route("addProduct")]
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
