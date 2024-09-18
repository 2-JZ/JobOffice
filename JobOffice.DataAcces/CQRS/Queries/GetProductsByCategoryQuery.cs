using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetProductsByCategoryQuery : QueryBase<List<Product>>
    {
        public int CategoryId { get; set; }

        public override async Task<List<Product>> Execute(JobOfficeContext context)
        {
            var products = await context.Products
                .Where(p => p.CategoryId == this.CategoryId)
                .ToListAsync();

            return products;
        }
    }
}
