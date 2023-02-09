using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            this.CreateMap<JobOffice.DataAcces.Entities.Product, Product>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.ProductName, y => y.MapFrom(z => z.ProductName))
               .ForMember(x => x.UnitPriceBrutto, y => y.MapFrom(z => z.UnitPriceBrutto))
               .ForMember(x => x.UnitPriceBrutto, y => y.MapFrom(z => z.UnitPriceBrutto))
               .ForMember(x => x.Discount, y => y.MapFrom(z => z.Discount))
               .ForMember(x => x.LastModified, y => y.MapFrom(z => z.LastModified));

            this.CreateMap<AddProductRequest, JobOffice.DataAcces.Entities.Product>();

            this.CreateMap<PutProductRequest, JobOffice.DataAcces.Entities.Product>();
        }
    }
}
