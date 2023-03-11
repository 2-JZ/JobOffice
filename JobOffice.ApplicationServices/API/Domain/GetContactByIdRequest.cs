using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContactByIdRequest : RequestBase, IRequest<GetContactByIdResponse>
    {
        public int Id { get; set; }
    }
}
