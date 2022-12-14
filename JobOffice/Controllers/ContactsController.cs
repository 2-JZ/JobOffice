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
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetContacts([FromQuery] GetContactsRequest request)
        {
            request = new GetContactsRequest();
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPut]
        [Route("{contactId}")]
        public async Task<IActionResult> PutContact([FromBody] PutContactRequest request)
        {
            //request = new PutContactRequest();
            
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
