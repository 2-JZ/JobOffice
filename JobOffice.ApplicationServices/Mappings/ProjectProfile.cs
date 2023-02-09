using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            this.CreateMap<AddProjectRequest, JobOffice.DataAcces.Entities.Project>();
                //.ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName))
                //.ForMember(x => x.ProjectEnd, y => y.MapFrom(z => z.ProjectEnd))
                //.ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                //.ForMember(x => x.ProjectStart, y => y.MapFrom(z => z.ProjectStart))
                //.ForMember(x => x.ProjectStart, y => y.MapFrom(z => z.ProjectStart));

            this.CreateMap<DeleteProjectRequest, JobOffice.DataAcces.Entities.Project>();

            this.CreateMap<JobOffice.DataAcces.Entities.Project, Project>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName))
                .ForMember(x => x.ProjectEnd, y => y.MapFrom(z => z.ProjectEnd))
                .ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                .ForMember(x => x.ProjectStart, y => y.MapFrom(z => z.ProjectStart))
                .ForMember(x => x.Employees, y => y.MapFrom(z => z.Employees))
                .ForMember(x => x.Contractors, y => y.MapFrom(z => z.Contractors))
                .ForMember(x => x.ProjectDescription, y => y.MapFrom(z => z.ProjectDescription));

            //.ForMember(x => x.ContractorNames, y => y.MapFrom(z => z.Contractors != null ? z.Contractors.Select(x => x.Name) : new List<string>()));
            //.ForMember(x => x.EmployeeNames, y => y.MapFrom(z => z.Employees != null ? z.Employees.Select(x=>x.Name) : new List<string>()) );


            this.CreateMap<PutProjectRequest, JobOffice.DataAcces.Entities.Project>();
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName))
                //.ForMember(x => x.ProjectEnd, y => y.MapFrom(z => z.ProjectEnd))
                //.ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                //.ForMember(x => x.ProjectStart, y => y.MapFrom(z => z.ProjectStart))
                //.ForMember(x => x.ProjectStart, y => y.MapFrom(z => z.ProjectStart));
        }



    }
}
