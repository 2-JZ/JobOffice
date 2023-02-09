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
        public InvoiceController(IMediator mediator, ILogger<InvoiceController> logger) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request)
        {
            request = new GetInvoicesRequest();
            return this.HandleRequest<GetInvoicesRequest, GetInvoicesResponse>(request);
        }

        [HttpGet]
        [Route("{invoiceId}")]
        public Task<IActionResult> GetInvoices([FromRoute] int invoiceId)
        {
            var request = new GetInvoiceRequest()
            {
                Id = invoiceId
            };
            return this.HandleRequest<GetInvoiceRequest, GetInvoiceResponse>(request);

        }

        [HttpDelete]
        [Route("{invoiceId}")]
        public Task<IActionResult> DeleteInvoice([FromRoute] int invoiceId)
        {
            var request = new DeleteInvoiceRequest()
            {
                Id = invoiceId
            };
            return this.HandleRequest<DeleteInvoiceRequest, DeleteInvoiceResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> PostInvoice([FromBody] AddInvoiceRequest request)
        {
            return this.HandleRequest<AddInvoiceRequest, AddInvoiceResponse>(request);
        }

        [HttpPut]
        [Route("invoiceId")]
        public Task<IActionResult> PutInvoice([FromBody] PutInvoiceRequest request)
        {
            return this.HandleRequest<PutInvoiceRequest, PutInvoiceResponse>(request);
        }
    }
}
