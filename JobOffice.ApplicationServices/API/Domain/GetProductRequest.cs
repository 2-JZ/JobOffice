using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetProductRequest :RequestBase, IRequest<GetProductResponse>
    {
        public int Id { get; set; }
    }
}
