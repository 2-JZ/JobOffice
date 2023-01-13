using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class DeleteProductCommand: CommandBase<Product, Product>
    {
        public int Id { get; set; }
        public override async Task<Product> Execute(JobOfficeContext context)
        {
            var productId = await context.Products.Where(a => a.Id == this.Id).FirstOrDefaultAsync();
            context.Products.Remove(productId);
            await context.SaveChangesAsync();
            return this.Parameter;


        }
    }
}
