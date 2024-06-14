using JobOffice.DataAcces;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

public class GetUserByEmailQuery : QueryBase<User>
{
    public string Email { get; set; }


    public override async Task<User> Execute(JobOfficeContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == this.Email);
        return user;
    }
}
