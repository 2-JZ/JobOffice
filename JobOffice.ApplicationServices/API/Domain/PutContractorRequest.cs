using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutContractorRequest : RequestBase, IRequest<PutContractorResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string NIP { get; set; }
        public bool? IsActive { get; set; }
        public string? country { get; set; }
    }
}
