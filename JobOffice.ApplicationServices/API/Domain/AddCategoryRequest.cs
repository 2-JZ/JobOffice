using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddCategoryRequest : RequestBase, IRequest<AddCategoryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; } 
    }
}
