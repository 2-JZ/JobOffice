using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.Entities;

namespace JobOffice.ApplicationServices.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            // Map from Entity to Domain Model (DTO)
            this.CreateMap<JobOffice.DataAcces.Entities.Invoice, JobOffice.ApplicationServices.API.Domain.Models.Invoice>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.CustomerName, y => y.MapFrom(z => z.CustomerName))
               .ForMember(x => x.CustomerEmail, y => y.MapFrom(z => z.CustomerEmail))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.InvoiceIssue, y => y.MapFrom(z => z.InvoiceIssue))
               .ForMember(x => x.PaymentDeadline, y => y.MapFrom(z => z.PaymentDeadline))
               .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
               .ForMember(x => x.TotalAmount, y => y.MapFrom(z => z.TotalAmount))
               .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid));

            // Map from AddInvoiceRequest DTO to Entity
            this.CreateMap<AddInvoiceRequest, JobOffice.DataAcces.Entities.Invoice>()
               .ForMember(x => x.CustomerName, y => y.MapFrom(z => z.CustomerName))
               .ForMember(x => x.CustomerEmail, y => y.MapFrom(z => z.CustomerEmail))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.InvoiceIssue, y => y.MapFrom(z => z.InvoiceIssue))
               .ForMember(x => x.PaymentDeadline, y => y.MapFrom(z => z.PaymentDeadline))
               .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
               .ForMember(x => x.TotalAmount, y => y.MapFrom(z => z.TotalAmount))
               .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid));

            // Map from PutInvoiceRequest DTO to Entity (for updating)
            this.CreateMap<PutInvoiceRequest, JobOffice.DataAcces.Entities.Invoice>()
               .ForMember(x => x.CustomerName, y => y.MapFrom(z => z.CustomerName))
               .ForMember(x => x.CustomerEmail, y => y.MapFrom(z => z.CustomerEmail))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.InvoiceIssue, y => y.MapFrom(z => z.InvoiceIssue))
               .ForMember(x => x.PaymentDeadline, y => y.MapFrom(z => z.PaymentDeadline))
               .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
               .ForMember(x => x.TotalAmount, y => y.MapFrom(z => z.TotalAmount))
               .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid));
               //.ForMember(x => x.InvoiceItems, y => y.MapFrom(z => z.Items)); // Maps the list of InvoiceItems
        }
    }
}
