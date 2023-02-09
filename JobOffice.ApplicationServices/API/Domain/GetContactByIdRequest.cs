using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContactByIdRequest : IRequest<GetContactByIdResponse>
    {
        public int Id { get; set; }
    }
}
