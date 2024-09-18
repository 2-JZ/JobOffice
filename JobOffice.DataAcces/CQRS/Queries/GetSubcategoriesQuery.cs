using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.Entities;
using JobOffice.DataAcces;
using Microsoft.EntityFrameworkCore;

public class GetSubcategoriesQuery : QueryBase<List<Category>>
{
    public int ParentId { get; set; }

    public override async Task<List<Category>> Execute(JobOfficeContext context)
    {
        return await context.Categories
                            .Where(c => c.ParentCategoryId == ParentId)
                            .ToListAsync();
    }
}
