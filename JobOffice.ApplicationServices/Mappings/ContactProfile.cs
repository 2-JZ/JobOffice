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
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            this.CreateMap<AddContactRequest, JobOffice.DataAcces.Entities.Contact>()
                .ForMember(x => x.Telephone, y => y.MapFrom(z => z.Telephone));

            //this.CreateMap<JobOffice.DataAcces.Entities.Contact, Contact>()

            //    .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            //    .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            //    .ForMember(x => x.ContactId, y => y.MapFrom(z => z.ContactId));
        }
            
    }
}
