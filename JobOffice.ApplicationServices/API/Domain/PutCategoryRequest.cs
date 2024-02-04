using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutCategoryRequest : RequestBase, IRequest<PutCategoryResponse>
    {
        public int Id { get; set; }
    }
}
