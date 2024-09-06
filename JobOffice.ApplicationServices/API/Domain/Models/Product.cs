namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPriceNetto { get; set; }
        public decimal? UnitPriceBrutto { get; set; }
        public float? Discount { get; set; }
        public DateTime? LastModified { get; set; }
        public int CategoryId {  get; set; }
        public byte[]? ImageData { get; set; }  
        public string? ImagePath { get; set; }

    }
}
