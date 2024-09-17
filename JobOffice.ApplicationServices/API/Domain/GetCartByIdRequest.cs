using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetCartByIdRequest : RequestBase, IRequest<GetCartByIdResponse>
    {
        public int CartId { get; set; }
    }
}
