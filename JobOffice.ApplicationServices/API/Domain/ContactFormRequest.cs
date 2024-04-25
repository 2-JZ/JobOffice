using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class ContactFormRequest : RequestBase, IRequest<ContactFormResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
