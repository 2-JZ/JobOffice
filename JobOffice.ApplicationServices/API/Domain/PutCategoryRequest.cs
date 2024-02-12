using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutCategoryRequest : RequestBase, IRequest<PutCategoryResponse>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public string? picturre { get; set; }
        public string? CategoryURL { get; set; }
        public bool? isActive { get; set; }
    }
}
