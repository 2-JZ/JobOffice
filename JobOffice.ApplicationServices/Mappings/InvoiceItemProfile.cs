using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.Entities;

namespace JobOffice.ApplicationServices.Mappings
{
    public class InvoiceItemProfile : Profile
    {
        public InvoiceItemProfile()
        {
            // Map from Entity to Domain Model (DTO)
            this.CreateMap<JobOffice.DataAcces.Entities.InvoiceItem, JobOffice.ApplicationServices.API.Domain.Models.InvoiceItem>()
               .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
               .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.ProductName))  
               .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
               .ForMember(x => x.TotalPrice, y => y.MapFrom(z => z.TotalPrice))  // Calculated total price in entity
               .ForMember(x => x.Discount, y => y.MapFrom(z => z.DiscountValue))  // Mapping discount to DiscountValue
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

            // Map from AddInvoiceItemRequest DTO to Entity
            this.CreateMap<AddInvoiceItemRequest, JobOffice.DataAcces.Entities.InvoiceItem>()
               .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
               .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
               .ForMember(x => x.DiscountValue, y => y.MapFrom(z => z.Discount))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

            // Map from PutInvoiceItemRequest DTO to Entity (for update)
            this.CreateMap<PutInvoiceItemRequest, JobOffice.DataAcces.Entities.InvoiceItem>()
               .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
               .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
               .ForMember(x => x.DiscountValue, y => y.MapFrom(z => z.Discount))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
