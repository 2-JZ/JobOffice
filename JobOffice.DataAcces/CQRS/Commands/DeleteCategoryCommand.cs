using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteCategoryCommand : CommandBase<Category, Category>
    {
        public int Id { get; set; }
        public override async Task<Category> Execute(JobOfficeContext context)
        {
            var category = await context.Categories.Where(a => a.Id == this.Id).FirstOrDefaultAsync();
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}