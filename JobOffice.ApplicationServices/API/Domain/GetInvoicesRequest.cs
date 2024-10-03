using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoicesRequest : RequestBase, IRequest<GetInvoicesResponse>
    {

    }
}
