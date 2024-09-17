using JobOffice.DataAcces.Entities;
using JobOffice.DataAcces.CQRS;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class CreateCartCommand : CommandBase<ShoppingCart, ShoppingCart>
    {
        public override async Task<ShoppingCart> Execute(JobOfficeContext context)
        {
            // Initialize the new cart with default values if needed
            var newCart = new ShoppingCart
            {
                CreatedAt = DateTime.Now,
                Status = "Active",
                TotalAmount = 0.00m  // Initialize TotalAmount if needed
            };

            // Add the new cart to the context
            await context.ShoppingCarts.AddAsync(newCart);

            // Save changes to the database
            await context.SaveChangesAsync();

            // Return the newly created cart
            return newCart;
        }
    }
}
