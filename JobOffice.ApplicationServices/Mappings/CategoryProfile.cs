using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<AddCategoryRequest, JobOffice.DataAcces.Entities.Category>();

            this.CreateMap<PutCategoryRequest, JobOffice.DataAcces.Entities.Category>();

            this.CreateMap<JobOffice.DataAcces.Entities.Category, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
                
        }
    }
}
