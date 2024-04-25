using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutCategoryRequest : RequestBase, IRequest<PutCategoryResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}

