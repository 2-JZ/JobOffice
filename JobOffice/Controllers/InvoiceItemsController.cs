using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceItemsController : ApiControllerBase
    {
        public InvoiceItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetInvoiceItems([FromQuery] GetInvoiceItemsRequest request)
        {
            request = new GetInvoiceItemsRequest();
            return this.HandleRequest<GetInvoiceItemsRequest, GetInvoiceItemsResponse>(request);
        }

        [HttpGet]
        [Route("invoiceItemId")]
        public Task<IActionResult> GetInvoiceItem([FromQuery] int invoiceItemId)
        {
            var request = new GetInvoiceItemRequest()
            {
                Id = invoiceItemId
            };
            return this.HandleRequest<GetInvoiceItemRequest, GetInvoiceItemResponse>(request);
        }

        [HttpDelete]
        [Route("{invoiceItemId}")]
        public Task<IActionResult> DeleteInvoiceItem([FromRoute] int invoiceItemId)
        {
            var request = new DeleteInvoiceItemRequest()
            {
                Id = invoiceItemId
            };
            return this.HandleRequest<DeleteInvoiceItemRequest, DeleteInvoiceItemResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> PostInvoiceItem([FromBody] AddInvoiceItemRequest request)
        {
            return this.HandleRequest<AddInvoiceItemRequest, AddInvoiceItemResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutInvoiceItem([FromBody] PutInvoiceItemRequest request)
        {
            return this.HandleRequest<PutInvoiceItemRequest, PutInvoiceItemResponse>(request);
        }
    }
}
