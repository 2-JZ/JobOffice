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
        [Route("authorization")]
        public Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddEmployee([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
    }
}
