using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ApiControllerBase
    {
        public ContactsController(IMediator mediator, ILogger<ContactsController> logger) : base(mediator)
        {
            logger.LogTrace("We are in Contacts.");
        }

        [HttpPost]
        [Route("addContact")]
        public Task<IActionResult> AddContact([FromBody] AddContactRequest request)
        {
            return this.HandleRequest<AddContactRequest, AddContactResponse>(request);
        }

        [HttpDelete]
        [Route("{contactId}")]
        public Task<IActionResult> DeleteContact([FromRoute] int contactId)
        {
            var request = new DeleteContactRequest()
            {
                Id = contactId
            };
            return this.HandleRequest<DeleteContactRequest, DeleteContactResponse>(request);

        }
        [HttpGet]
        [Route("{contactId}")]
        public Task<IActionResult> GetContactById([FromRoute] int contactId)
        {
            var request = new GetContactByIdRequest()
            {
                Id = contactId
            };
            return this.HandleRequest<GetContactByIdRequest, GetContactByIdResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetContacts([FromQuery] GetContactsRequest request)
        {
            return this.HandleRequest<GetContactsRequest, GetContactsResponse>(request);
        }
        
        [HttpPut]
        [Route("contactId")]
        public Task<IActionResult> PutContact([FromBody] PutContactRequest request)
        {
            return this.HandleRequest<PutContactRequest, PutContactResponse>(request);
        }

        [HttpPost]
        [Route("ContactForm")]
        public Task<IActionResult> AddContactForm([FromBody] ContactFormRequest request)
        {
            // Tutaj możesz skorzystać z MediatR do obsługi formularza kontaktowego
            return this.HandleRequest<ContactFormRequest, ContactFormResponse>(request);
        }

    }
}
