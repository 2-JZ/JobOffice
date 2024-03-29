﻿using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ValidateUserRequest :  IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
