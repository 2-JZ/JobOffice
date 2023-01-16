using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator)
        {
            logger.LogTrace("We are in UserCtroler.");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetUsers")]
        public Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUsers([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
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
