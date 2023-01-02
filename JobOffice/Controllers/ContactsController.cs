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
    }
}
