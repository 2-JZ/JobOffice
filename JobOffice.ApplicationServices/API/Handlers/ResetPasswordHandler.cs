using AutoMapper;
using MediatR;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.ApplicationServices.Components.HashingPassword;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using JobOffice.DataAcces.CQRS;

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
        var query = new GetUserByEmailQuery()
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

        var userMappedFromRequest = this.mapper.Map<JobOffice.DataAcces.Entities.User>(request);

        var newPassword = GenerateRandomPassword();
        var hashedPassword = hashingPassword.Hash(newPassword);
        user.Password = hashedPassword[1];

        var command = new UpdateUserPasswordCommand
        {
            Parameter = userMappedFromRequest
        };

        await commandExecutor.Execute(command);

        await SendPasswordEmail(request.Email, newPassword);

        return new ResetPasswordResponse
        {
            Success = true
        };
    }

    private string GenerateRandomPassword()
    {
        // Implementacja generowania losowego hasła
        return "NewRandomPassword123";
    }

    private async Task SendPasswordEmail(string email, string newPassword)
    {
        var smtpClient = new SmtpClient("localhost", 25);
        var mailMessage = new MailMessage
        {
            From = new MailAddress("no-reply@example.com"),
            Subject = "Your new password",
            Body = $"Your new password is: {newPassword}",
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
