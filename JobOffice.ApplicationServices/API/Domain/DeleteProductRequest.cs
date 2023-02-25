using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteProductRequest:RequestBase, IRequest<DeleteProductResponse>
    {
        public int Id { get; set; }
    }
}
