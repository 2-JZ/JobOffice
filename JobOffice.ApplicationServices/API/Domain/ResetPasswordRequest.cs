using JobOffice.DataAcces.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ResetPasswordRequest : RequestBase, IRequest<ResetPasswordResponse>
    {
        public string Email { get; set; } //email is also username
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Username { get; set; }
        
        //public string Password { get; set; }
        //public string Salt { get; set; }
    }

}
