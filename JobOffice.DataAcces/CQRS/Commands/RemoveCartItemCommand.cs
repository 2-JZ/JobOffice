using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class RemoveCartItemCommand : CommandBase<(int CartId, int ProductId), bool>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public override async Task<bool> Execute(JobOfficeContext context)
        {
            var cart = await context.ShoppingCarts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == CartId);
            if (cart != null)
            {
                var itemToRemove = cart.Items.FirstOrDefault(i => i.ProductId == ProductId);
                if (itemToRemove != null)
                {
                    cart.Items.Remove(itemToRemove);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
