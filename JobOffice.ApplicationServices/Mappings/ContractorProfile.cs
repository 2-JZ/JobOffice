using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {

            this.CreateMap<AddContractorRequest, JobOffice.DataAcces.Entities.Contractor>();
            //.ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            //.ForMember(x => x.NIP, y => y.MapFrom(z => z.NIP))
            //.ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
            //.ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
            //.ForMember(x => x.country, y => y.MapFrom(z => z.country));

            this.CreateMap<JobOffice.DataAcces.Entities.Contractor, Contractor>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Code))
                .ForMember(x => x.NIP, y => y.MapFrom(z => z.NIP))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                //.ForMember(x => x.Projects, y => y.MapFrom(z => z.Projects != null ? z.Projects.Select(x => x.Adress) : new List<string>()))
                .ForMember(x => x.ContactsWhatsAPP, y => y.MapFrom(z => z.Contacts != null ? z.Contacts.Select(x => x.WhatsApp) : new List<string>()));
                //.ForMember(x => x.ProjectCoutries, y => y.MapFrom(z => z.Projects != null ? z.Projects.Select(x=>x.Adress) : new List<string>()));

            this.CreateMap<PutContractorRequest, JobOffice.DataAcces.Entities.Contractor>();
                //.ForMember(x=>x.Id, y=>y.MapFrom(z=>z.Id))
                //.ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                //.ForMember(x => x.NIP, y => y.MapFrom(z => z.NIP))
                //.ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                //.ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                //.ForMember(x => x.country, y => y.MapFrom(z => z.country));

        }
    }
}
