using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContactsRequest : RequestBase, IRequest<GetContactsResponse>
    {
    }
}
