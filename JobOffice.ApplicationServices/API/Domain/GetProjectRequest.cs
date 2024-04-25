using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetProjectRequest : IRequest<GetProjectResponse>
    {
        public int Id { get; set; }
    }
}
