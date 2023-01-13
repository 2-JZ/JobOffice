using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteProductRequest:IRequest<DeleteProductResponse>
    {
        public int Id { get; set; }
    }
}
