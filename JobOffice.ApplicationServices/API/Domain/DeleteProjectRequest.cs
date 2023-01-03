using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteProjectRequest : IRequest<DeleteProjectResponse>
    {
        public int Id { get; set; }
    }
}
