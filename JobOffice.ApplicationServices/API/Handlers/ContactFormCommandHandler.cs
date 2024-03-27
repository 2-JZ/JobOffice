using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.Components.ContactForm;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class ContactFormCommandHandler : IRequestHandler<ContactFormRequest, ContactFormResponse>
    {
        private readonly IEmailService _emailService;

        public ContactFormCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<ContactFormResponse> Handle(ContactFormRequest request, CancellationToken cancellationToken)
        {
            // Logika obsługi formularza kontaktowego, np. wysyłanie e-maila
            await _emailService.SendEmail(request.Name, request.Email, request.Message);

            // Zwróć true, jeśli obsługa zakończyła się sukcesem
            return new ContactFormResponse()
            {

            };
        }
    }
}
