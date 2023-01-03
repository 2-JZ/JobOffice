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
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<DeleteEmployeeRequest, JobOffice.DataAcces.Entities.Employee>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.EmployeeId));

            this.CreateMap<UpdateEmployeeByIdRequest, JobOffice.DataAcces.Entities.Employee>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.employeeId))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.ContactId, y => y.MapFrom(z => z.ContactId));

            this.CreateMap<AddEmployeeRequest, JobOffice.DataAcces.Entities.Employee>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname));
 //               .ForMember(x => x.ContactId, y => y.MapFrom(z=> z.ContactId));

            this.CreateMap<JobOffice.DataAcces.Entities.Employee, Employee>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname));
//                .ForMember(x => x.ContactId, y => y.MapFrom(z => z.ContactId));
                

                



        }
    }
}
