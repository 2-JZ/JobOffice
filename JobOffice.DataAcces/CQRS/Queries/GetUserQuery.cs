using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(JobOfficeContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
