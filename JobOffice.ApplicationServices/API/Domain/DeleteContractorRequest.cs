using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteContractorRequest :RequestBase, IRequest<DeleteContractorResponse>
    {
        public int Id { get; set; }
    }
}
