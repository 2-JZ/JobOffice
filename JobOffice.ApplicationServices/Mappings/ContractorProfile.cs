using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ContractorProfile : Profile
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string NIP { get; set; }
        public bool IsActive { get; set; }
        public string? country { get; set; }
        public List<Project>? Projects { get; set; }
        public List<Contact>? Contacts { get; set; }
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
                .ForMember(x => x.Projects, y => y.MapFrom(z => z.Projects))
                .ForMember(x => x.Contacts, y => y.MapFrom(z => z.Contacts))
                .ForMember(x => x.country, y => y.MapFrom(z => z.country));

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
