using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddCartItemCommand : CommandBase<CartItem, CartItem>
    {
        public int CartId { get; set; }

        public override async Task<CartItem> Execute(JobOfficeContext context)
        {
            var cart = await context.ShoppingCarts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == CartId);
            if (cart != null)
            {
                cart.Items.Add(this.Parameter);
                await context.SaveChangesAsync();
                return this.Parameter;
            }
            return null;
        }
    }
}
