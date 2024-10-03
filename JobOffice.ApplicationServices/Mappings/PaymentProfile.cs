using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.Entities;

namespace JobOffice.ApplicationServices.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            // Map from Entity to Domain Model (DTO)
            // This should be singular
            this.CreateMap<JobOffice.DataAcces.Entities.Payment, JobOffice.ApplicationServices.API.Domain.Models.Payment>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PaymentIntentId, y => y.MapFrom(z => z.PaymentIntentId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.PaymentMethodId, y => y.MapFrom(z => z.PaymentMethodId))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.CustomerId, y => y.MapFrom(z => z.CustomerId));

            // Map from AddPaymentRequest DTO to Entity
            this.CreateMap<AddPaymentRequest, JobOffice.DataAcces.Entities.Payment>()
                //.ForMember(x => x.PaymentIntentId, y => y.MapFrom(z => z.PaymentIntentId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                //.ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.PaymentMethodId, y => y.MapFrom(z => z.PaymentMethodId))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => DateTime.UtcNow)) // Automatically set created time
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.CustomerId, y => y.MapFrom(z => z.CustomerId));


        }
    }
}
