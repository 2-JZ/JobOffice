using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public async override Task<List<User>> Execute(JobOfficeContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}
