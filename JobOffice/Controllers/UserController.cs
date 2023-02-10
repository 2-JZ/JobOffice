using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobOffice.Controllers
{
    [Authorize]
    [ApiController] 
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator ) : base(mediator)
        {
        
        }
        //[AllowAnonymous]
        [HttpGet]
        [Route("Authorization")]
        public Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }

        //[HttpDelete]
        //[Route("{contactId}")]
        //public Task<IActionResult> DeleteContact([FromRoute] int contactId)
        //{
        //    var request = new DeleteContactRequest()
        //    {
        //        Id = contactId
        //    };
        //    return this.HandleRequest<DeleteContactRequest, DeleteContactResponse>(request);
        //}

        //[HttpGet]
        //[Route("{contactId}")]
        //public Task<IActionResult> GetContactById([FromRoute] int contactId)
        //{
        //    var request = new GetContactByIdRequest()
        //    {
        //        Id = contactId
        //    };
        //    return this.HandleRequest<GetContactByIdRequest, GetContactByIdResponse>(request);
        //}



        //[HttpPut]
        //[Route("{contactId}")]
        //public Task<IActionResult> PutContact([FromBody] PutContactRequest request)
        //{
        //    return this.HandleRequest<PutContactRequest, PutContactResponse>(request);
        //}

    }
}
