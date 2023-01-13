using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ApiControllerBase
    {
        public InvoiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request )
        {
            request = new GetInvoicesRequest();
            return await this.HandleRequest<GetInvoicesRequest, GetInvoicesResponse>(request);

        }

        [HttpGet]
        [Route("{invoiceId}")]
        public async Task<IActionResult> GetInvoices([FromRoute] int invoiceId)
        {
            var request = new GetInvoiceRequest()
            {
                Id = invoiceId
            };
            return await this.HandleRequest<GetInvoiceRequest, GetInvoiceResponse>(request);

        }

        [HttpDelete]
        [Route("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int invoiceId)
        {
            var request = new DeleteInvoiceRequest()
            {
                Id = invoiceId
            };
            return await this.HandleRequest<DeleteInvoiceRequest, DeleteInvoiceResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostInvoice([FromBody] AddInvoiceRequest request)
        {
            return await this.HandleRequest<AddInvoiceRequest, AddInvoiceResponse>(request);
        }

        [HttpPut]
        [Route("invoiceId")]
        public async Task<IActionResult> PutInvoice([FromBody] PutInvoiceRequest request)
        {
            return await this.HandleRequest<PutInvoiceRequest, PutInvoiceResponse>(request);

        }
    }
}
