using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteInvoiceItemRequest: RequestBase, IRequest<DeleteInvoiceItemResponse>
    {
        public int Id { get; set; }
    }
}
