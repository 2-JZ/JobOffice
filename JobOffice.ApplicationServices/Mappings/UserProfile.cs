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
            this.CreateMap<ResetPasswordRequest, JobOffice.DataAcces.Entities.User>();


            this.CreateMap<JobOffice.DataAcces.Entities.User, User>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username));

                //.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
