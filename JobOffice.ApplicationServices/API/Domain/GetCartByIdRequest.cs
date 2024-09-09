using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetCartByIdRequest : IRequest<GetCartByIdResponse>
    {
        public int CartId { get; set; }
    }
}
