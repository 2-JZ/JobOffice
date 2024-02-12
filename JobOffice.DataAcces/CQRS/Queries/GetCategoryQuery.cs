using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetCategoryByIdQuery : QueryBase<Category>
    {
        public int Id { get; set; }
        public async override Task<Category> Execute(JobOfficeContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == this.Id);
            return category;
        }
    }
}
