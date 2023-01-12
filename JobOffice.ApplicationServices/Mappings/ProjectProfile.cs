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
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            this.CreateMap<AddProjectRequest, JobOffice.DataAcces.Entities.Project>()
                .ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName));

            this.CreateMap<DeleteProjectRequest, JobOffice.DataAcces.Entities.Project>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<JobOffice.DataAcces.Entities.Project, Project>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName))
                .ForMember(x => x.ContractorNames, y => y.MapFrom(z => z.Contractors != null ? z.Contractors.Select(x => x.Name) : new List<string>()));
                //.ForMember(x => x.EmployeeNames, y => y.MapFrom(z => z.Employees != null ? z.Employees.Select(x=>x.Name) : new List<string>()) );


            this.CreateMap<PutProjectRequest, JobOffice.DataAcces.Entities.Project>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProjectName, y => y.MapFrom(z => z.ProjectName));


        }



    }
}
