using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(JobOfficeContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
