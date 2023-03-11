using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContractorRequest : RequestBase, IRequest<GetContractorResponse>
    {
        public int Id { get; set; }
    }
}
