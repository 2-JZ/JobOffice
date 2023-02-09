using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetProductQuery: QueryBase<Product>
    {
        public int Id { get; set; }
        public async override Task<Product> Execute(JobOfficeContext context)
        {

            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == this.Id);
            return product;

        }
    }
}
