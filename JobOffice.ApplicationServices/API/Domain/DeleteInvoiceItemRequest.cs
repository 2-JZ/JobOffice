using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteInvoiceItemRequest: IRequest<DeleteInvoiceItemResponse>
    {
        public int Id { get; set; }
    }
}
