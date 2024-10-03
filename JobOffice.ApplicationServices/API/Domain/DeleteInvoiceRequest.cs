using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteInvoiceRequest: RequestBase, IRequest<DeleteInvoiceResponse>
    {
        public int Id { get; set; }
    }
}
