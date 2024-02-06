using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddCategoryRequest : RequestBase, IRequest<AddCategoryResponse>
    {
    }
}
