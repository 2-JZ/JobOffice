using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutProductRequest: IRequest<PutProductResponse>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPriceNetto { get; set; }
        public decimal? UnitPriceBrutto { get; set; }
        public float? Discount { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
