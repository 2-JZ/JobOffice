using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutContactRequest : RequestBase, IRequest<PutContactResponse>
    {
        public int Id { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string? Skype { get; set; }
        public string? WhatsApp { get; set; }
    }
}
