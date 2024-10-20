﻿using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddProductRequest: RequestBase, IRequest<AddProductResponse>
    {
        public string ProductName { get; set; }
        public decimal? UnitPriceNetto { get; set; }
        public decimal? UnitPriceBrutto { get; set; }
        public float? Discount { get; set; }
        public DateTime? LastModified { get; set; }
        public int CategoryId { get; set; }
        public byte[]? ImageData { get; set; }  
    }
}
