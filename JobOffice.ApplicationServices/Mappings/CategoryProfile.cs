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
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Picture, y => y.MapFrom(z => z.Picture))
                .ForMember(x => x.CategoryURL, y => y.MapFrom(z => z.CategoryURL))
                .ForMember(x => x.IdSubCategory, y => y.MapFrom(z => z.IdSubCategory))
                .ForMember(x => x.isActive, y => y.MapFrom(z => z.isActive))
                .ForMember(x => x.SubCategories, y => y.MapFrom(z => z.SubCategories))
                .ForMember(x => x.CreatedTime, y => y.MapFrom(z => z.CreatedTime));
        }
    }
}
