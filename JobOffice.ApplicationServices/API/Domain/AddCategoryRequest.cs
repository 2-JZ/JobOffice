using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddCategoryRequest : RequestBase, IRequest<AddCategoryResponse>
    {
        public int Name { get; set; }
        public string Description { get; set; }
        public string? picturre { get; set; }
        public string? CategoryURL { get; set; }
        public bool? isActive { get; set; }
    }
}
