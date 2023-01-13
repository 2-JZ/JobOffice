using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteInvoiceRequest: IRequest<DeleteInvoiceResponse>
    {
        public int Id { get; set; }
    }
}
