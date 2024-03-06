using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.ApplicationServices.Components.ContactForm;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmail(string name, string email, string message)
    {
        var smtpClient = new SmtpClient(_smtpSettings.Server)
        {
            Port = _smtpSettings.Port,
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
            EnableSsl = _smtpSettings.UseSsl,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpSettings.Username),
            Subject = "Wiadomość z formularza kontaktowego",
            Body = $"Imię: {name}\nE-mail: {email}\n\nWiadomość:\n{message}",
            IsBodyHtml = false,
        };

        mailMessage.To.Add("adres_odbiorcy@example.com"); // add adress e-mail 

        await smtpClient.SendMailAsync(mailMessage);
    }
}