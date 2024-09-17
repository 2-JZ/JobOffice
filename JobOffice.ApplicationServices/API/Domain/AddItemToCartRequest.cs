using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddItemToCartRequest : RequestBase, IRequest<AddItemToCartResponse>
    {
        public int CartId { get; set; }  // Added CartId property
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
    }
}
