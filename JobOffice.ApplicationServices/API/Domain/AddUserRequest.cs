using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddUserRequest: IRequest<AddUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        //public string Salt { get; set; }
    }
}
