using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class PutCategoryCommand : CommandBase<Category, Category>
    {
        public async override Task<Category> Execute(JobOfficeContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
