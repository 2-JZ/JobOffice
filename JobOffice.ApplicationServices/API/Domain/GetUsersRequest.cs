using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetUsersRequest:RequestBase, IRequest<GetUsersResponse>
    {
    }
}
