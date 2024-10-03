using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoiceItemsRequest : RequestBase, IRequest<GetInvoiceItemsResponse>
    {
    }
}
