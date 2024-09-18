using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetProductsByCategoryRequest : RequestBase, IRequest<GetProductsByCategoryResponse>
    {
        public int CategoryId { get; set; }
    }
}
