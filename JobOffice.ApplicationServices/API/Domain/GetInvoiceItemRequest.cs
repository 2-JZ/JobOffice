using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetInvoiceItemRequest: IRequest<GetInvoiceItemResponse>
    {
        public int Id { get; set; }
    }
}
