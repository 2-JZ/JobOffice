using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ResetPasswordRequest : RequestBase, IRequest<ResetPasswordResponse>
    {
        public string Email { get; set; }
    }

}
