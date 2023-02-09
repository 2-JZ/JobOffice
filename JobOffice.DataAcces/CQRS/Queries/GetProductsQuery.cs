using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetProductsQuery: QueryBase<List<Product>>
    {
        public async override Task<List<Product>> Execute(JobOfficeContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }
    }
}
