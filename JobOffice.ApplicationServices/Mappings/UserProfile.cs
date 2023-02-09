using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            this.CreateMap<AddUserRequest, JobOffice.DataAcces.Entities.User>();

            this.CreateMap<JobOffice.DataAcces.Entities.User, User>();
                //.ForMember(x => x.FirstName, y => y.MapFrom(z => z.LastName))
                //.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
