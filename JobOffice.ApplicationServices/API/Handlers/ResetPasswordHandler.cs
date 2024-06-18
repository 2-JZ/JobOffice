using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.Components.HashingPassword;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IHashingPassword hashingPassword;

        public ResetPasswordHandler(
            IMapper mapper,
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor,
            IHashingPassword hashingPassword)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.hashingPassword = hashingPassword;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            // Pobranie użytkownika na podstawie emaila
            var query = new GetUserByEmailQuery
            {
                Email = request.Email
            };

            var user = await queryExecutor.Execute(query);
            if (user == null)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    ErrorMessage = "User not found."
                };
            }

            // Generowanie nowego hasła i jego hashowanie
            var newPassword = GenerateRandomPassword();
            var hashedPassword = hashingPassword.Hash(newPassword);
            user.Salt = hashedPassword[0];
            user.Password = hashedPassword[1];

            // Aktualizacja hasła w bazie danych
            var updateUserCommand = new UpdateUserPasswordCommand
            {
                Parameter = user
            };

            var updatedUser = await commandExecutor.Execute(updateUserCommand);
            if (updatedUser == null)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to update password."
                };
            }

            // Wysyłanie nowego hasła na email
            await SendPasswordEmail(request.Email, newPassword);

            return new ResetPasswordResponse
            {
                Success = true
            };
        }

        private string GenerateRandomPassword()
        {
            const int length = 8;
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }

        private async Task SendPasswordEmail(string email, string newPassword)
        {
            try
            {
                using (var smtpClient = new SmtpClient("localhost", 25))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("username", "password");
                    smtpClient.EnableSsl = false; // TLS jest wyłączony dla smtp4dev

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("no-reply@example.com"),
                        Subject = "Your new password",
                        Body = $"Your new password is: {newPassword}",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(email);

                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email sent successfully to " + email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email. Error: " + ex.Message);
                // Logowanie błędu do systemu logowania, np. NLog, Serilog itp.
                throw;
            }
        }
    }
}
