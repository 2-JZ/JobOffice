using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoiceRequest: RequestBase, IRequest<GetInvoiceResponse>
    {
        public int Id { get; set; }
    }
}
