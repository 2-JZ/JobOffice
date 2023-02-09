using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            this.CreateMap<AddContactRequest, JobOffice.DataAcces.Entities.Contact>();

            this.CreateMap<PutContactRequest, JobOffice.DataAcces.Entities.Contact>();

            this.CreateMap<JobOffice.DataAcces.Entities.Contact, Contact>()
                .ForMember(x => x.Telephone, y => y.MapFrom(z => z.Telephone))
                .ForMember(x => x.Skype, y => y.MapFrom(z => z.Skype))
                .ForMember(x => x.WhatsApp, y => y.MapFrom(z => z.WhatsApp))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
                .ForMember(x => x.ContractorId, y => y.MapFrom(z => z.ContractorId))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));
        }
            
    }
}
