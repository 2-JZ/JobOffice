using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetCategoriesRequest : RequestBase, IRequest <GetCategoriesResponse>
    {
    }
}
