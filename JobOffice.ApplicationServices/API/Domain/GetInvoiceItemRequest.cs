using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoiceItemRequest: RequestBase, IRequest<GetInvoiceItemResponse>
    {
        public int Id { get; set; }
    }
}
