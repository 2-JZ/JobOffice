using JobOffice.DataAcces;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

public class UpdateUserPasswordCommand : CommandBase<User, User>
{
    public User user { get; set; }
    public int Id { get; set; }
    public string Password { get; set; }


    public override async Task<User> Execute(JobOfficeContext context)
    {
        context.ChangeTracker.Clear();
        context.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
