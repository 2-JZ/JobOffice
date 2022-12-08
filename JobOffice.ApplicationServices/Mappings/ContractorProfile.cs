using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {

            this.CreateMap<AddContractorRequest, JobOffice.DataAcces.Entities.Contractor>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ContactId, y => y.MapFrom(z => z.ContactId));

            this.CreateMap<JobOffice.DataAcces.Entities.Contractor, Contractor>()

                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ContactId, y => y.MapFrom(z => z.ContactId));


        }
    }
}
