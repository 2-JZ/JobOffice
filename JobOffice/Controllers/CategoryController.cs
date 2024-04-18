using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase
    {
        public CategoryController(IMediator mediator, ILogger<InvoiceController> logger) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequest request)
        {
            request = new GetCategoriesRequest();
            return this.HandleRequest<GetCategoriesRequest, GetCategoriesResponse>(request);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public Task<IActionResult> GetCategory([FromRoute] int categoryId)
        {
            var request = new GetCategoryByIdRequest()
            {
                Id = categoryId
            };
            return this.HandleRequest<GetCategoryByIdRequest, GetCategoryByIdResponse>(request);

        }

        [HttpDelete]
        [Route("{categoryId}")]
        public Task<IActionResult> DeleteCategoryInvoice([FromRoute] int categoryId)
        {
            var request = new DeleteCategoryRequest()
            {
                Id = categoryId
            };
            return this.HandleRequest<DeleteCategoryRequest, DeleteCategoryResponse>(request);
        }
        
        //[AllowAnonymous]
        [HttpPost]
        [Route("AddCategory")]
        [Route("")]
        public Task<IActionResult> PostCategory([FromBody] AddCategoryRequest request)
        {
            return this.HandleRequest<AddCategoryRequest, AddCategoryResponse>(request);
        }

        [HttpPut]
        [Route("{categoryId}")]
        public Task<IActionResult> PutCategory([FromBody] PutCategoryRequest request)
        {
            return this.HandleRequest<PutCategoryRequest, PutCategoryResponse>(request);
        }
    }
}
