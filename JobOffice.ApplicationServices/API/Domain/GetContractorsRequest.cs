using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContractorsRequest :RequestBase, IRequest<GetContractorsResponse>
    {
    }
}
