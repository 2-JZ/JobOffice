using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public int Id { get; set; }
    }
}
