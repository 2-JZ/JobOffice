﻿using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobOffice.Controllers
{
    [Authorize]
    [ApiController] 
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator ) : base(mediator)
        {
        
        }
        //[AllowAnonymous]
        [HttpGet]
        [Route("users")]
        public Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("reset-password")]
        public Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return this.HandleRequest<ResetPasswordRequest, ResetPasswordResponse>(request);
        }
    }
}

