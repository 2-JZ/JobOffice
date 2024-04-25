using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoiceRequest: IRequest<GetInvoiceResponse>
    {
        public int Id { get; set; }
    }
}
