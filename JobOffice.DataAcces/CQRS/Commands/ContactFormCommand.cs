using MediatR;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class ContactFormCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
