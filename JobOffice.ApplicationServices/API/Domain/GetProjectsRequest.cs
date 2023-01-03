using JobOffice.ApplicationServices.API.Domain.Models;
using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetProjectsRequest : IRequest<GetProjectsResponse>
    {
    }
}
