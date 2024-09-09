using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddCategoryCommand : CommandBase<Category, Category>
    {

        public override async Task<Category> Execute(JobOfficeContext context)
        {
            await context.Categories.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
