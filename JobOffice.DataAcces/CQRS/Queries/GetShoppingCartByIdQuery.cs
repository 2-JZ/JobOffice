using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetShoppingCartByIdQuery : QueryBase<ShoppingCart>
    {
        public int Id { get; set; }

        public async override Task<ShoppingCart> Execute(JobOfficeContext context)
        {
            return await context.ShoppingCarts
                                .Include(cart => cart.Items)
                                .FirstOrDefaultAsync(cart => cart.CartId == this.Id);
        }
    }
}
