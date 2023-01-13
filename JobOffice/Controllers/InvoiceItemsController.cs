using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceItemsController:ApiControllerBase
    {
        public InvoiceItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInvoiceItems([FromQuery] GetInvoiceItemsRequest request)
        {
            request = new GetInvoiceItemsRequest();
            return await this.HandleRequest<GetInvoiceItemsRequest, GetInvoiceItemsResponse>(request);

        }

        [HttpGet]
        [Route("invoiceItemId")]
        public async Task<IActionResult> GetInvoiceItem([FromQuery] int invoiceItemId)
        {
            var request = new GetInvoiceItemRequest()
            {
                Id = invoiceItemId
            };
            return await this.HandleRequest<GetInvoiceItemRequest, GetInvoiceItemResponse>(request);
        }

        [HttpDelete]
        [Route("{invoiceItemId}")]
        public async Task<IActionResult> DeleteInvoiceItem([FromRoute] int invoiceItemId)
        {
            var request = new DeleteInvoiceItemRequest()
            {
                Id = invoiceItemId
            };
            return await this.HandleRequest<DeleteInvoiceItemRequest, DeleteInvoiceItemResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostInvoiceItem([FromBody] AddInvoiceItemRequest request)
        {
            return await this.HandleRequest<AddInvoiceItemRequest, AddInvoiceItemResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutInvoiceItem([FromBody] PutInvoiceItemRequest request)
        {
            return await this.HandleRequest<PutInvoiceItemRequest, PutInvoiceItemResponse>(request);
        }
    }
}
