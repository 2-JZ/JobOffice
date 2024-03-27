namespace JobOffice.ApplicationServices.Components.ContactForm
{
    public interface IEmailService
    {
        Task SendEmail(string name, string email, string message);
    }
}
