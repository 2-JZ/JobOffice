using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteContactRequest : RequestBase, IRequest<DeleteContactResponse>
    {
        public int Id { get; set; }
    }
}
