using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class InvoiceProfile: Profile
    {
        public InvoiceProfile()
        {
            this.CreateMap<JobOffice.DataAcces.Entities.Invoice, Invoice>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.ContractorId, y => y.MapFrom(z => z.ContractorId))
               .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.PaymentDeadline, y => y.MapFrom(z => z.PaymentDeadline))
               .ForMember(x => x.InvoiceIssue, y => y.MapFrom(z => z.InvoiceIssue))
               .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
               .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));

            this.CreateMap<AddInvoiceRequest, JobOffice.DataAcces.Entities.Invoice>();
            this.CreateMap<PutInvoiceRequest, JobOffice.DataAcces.Entities.Invoice>();
        }
    }
}
