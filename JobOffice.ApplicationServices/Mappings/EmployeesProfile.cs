using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.Mappings
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<DeleteEmployeeRequest, JobOffice.DataAcces.Entities.Employee>();

            this.CreateMap<UpdateEmployeeByIdRequest, JobOffice.DataAcces.Entities.Employee>();
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.employeeId))
                //.ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                //.ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                //.ForMember(x => x.City, y => y.MapFrom(z => z.City))
                //.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                //.ForMember(x => x.Salary, y => y.MapFrom(z => z.Salary))
                //.ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode));

            this.CreateMap<AddEmployeeRequest, JobOffice.DataAcces.Entities.Employee>();
                //.ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                //.ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                //.ForMember(x => x.City, y => y.MapFrom(z => z.City))
                //.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                //.ForMember(x => x.Salary, y => y.MapFrom(z => z.Salary))
                //.ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode));
                ////.ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                ////.ForMember(x => x.Login, y => y.MapFrom(z => z.Login));

            this.CreateMap<JobOffice.DataAcces.Entities.Employee, Employee>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Adress, y => y.MapFrom(z => z.Adress))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.DateOfEmployment, y => y.MapFrom(z => z.DateOfEmployment))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.Salary))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.ProjectId, y => y.MapFrom(z => z.ProjectId))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login));







        }
    }
}
