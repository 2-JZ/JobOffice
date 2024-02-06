using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteCategoryRequest: RequestBase, IRequest<DeleteCategoryResponse>
    {
        public int Id { get; set; }
}
}
