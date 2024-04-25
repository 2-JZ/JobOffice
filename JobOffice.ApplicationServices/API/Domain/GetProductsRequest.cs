using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetProductsRequest: RequestBase, IRequest<GetProductsResponse>
    {
    }
}
