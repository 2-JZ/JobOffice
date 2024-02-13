using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetCategoriesQuery : QueryBase<List<Category>>
    {
        public async override Task<List<Category>> Execute(JobOfficeContext context)
        {
            var category = await context.Categories.ToListAsync();
            return category;
        }
    }
}
