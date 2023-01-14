using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class InvoiceItemProfile: Profile
    {
        public InvoiceItemProfile()
        {            
                this.CreateMap<JobOffice.DataAcces.Entities.InvoiceItem, InvoiceItem>()
                   .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                   .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                   .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
                   .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                   .ForMember(x => x.TotalPrice, y => y.MapFrom(z => z.TotalPrice))
                   .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                   .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                   .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

                this.CreateMap<AddInvoiceItemRequest, JobOffice.DataAcces.Entities.InvoiceItem>();
                
                this.CreateMap<PutInvoiceItemRequest, JobOffice.DataAcces.Entities.InvoiceItem>();
        }
    }
}
