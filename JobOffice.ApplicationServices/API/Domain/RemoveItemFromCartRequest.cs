using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class RemoveItemFromCartRequest : IRequest<RemoveItemFromCartResponse>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
