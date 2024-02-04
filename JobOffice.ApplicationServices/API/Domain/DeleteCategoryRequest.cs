using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    internal class DeleteCategoryRequest: RequestBase, IRequest<DeleteCategoryResponse>
    {
        public int Id { get; set; }
}
}
