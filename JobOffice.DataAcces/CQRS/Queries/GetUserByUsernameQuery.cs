using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetUserByUsernameQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public override async Task<User> Execute(JobOfficeContext context)
        {
            var Username = await context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);
            return Username;
        }
    }
}
