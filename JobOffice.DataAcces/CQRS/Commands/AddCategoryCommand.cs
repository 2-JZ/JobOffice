using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddCategoryCommand : CommandBase<Category, Category>
    {
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public int? ParentCategoryId { get; set; }

        public override async Task<Category> Execute(JobOfficeContext context)
        {
            await context.Categories.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
