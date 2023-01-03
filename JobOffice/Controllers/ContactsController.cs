using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        IMediator mediator;
        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{contactId}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int contactId)
        {
            var request = new DeleteContactRequest()
            {
                Id = contactId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{contactId}")]
        public async Task<IActionResult> GetContactById([FromRoute] int contactId)
        {
            var request = new GetContactByIdRequest()
            {
                Id = contactId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

    }
}
