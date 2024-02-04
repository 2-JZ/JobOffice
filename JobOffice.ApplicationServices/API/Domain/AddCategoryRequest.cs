using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    internal class AddCategoryRequest : RequestBase, IRequest<AddCategoryResponse>
    {
    }
}
