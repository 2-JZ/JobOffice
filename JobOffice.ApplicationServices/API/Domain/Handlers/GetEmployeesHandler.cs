using JobOffice.DataAcces;
using JobOffice.DataAcces.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace JobOffice.ApplicationServices.API.Domain.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeesHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;

        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = await this.employeeRepository.GetAll();
            var mappedEmployees = this.mapper.Map<List<Domain.Models.Employee>>(employees);
            
            //var domainEmployees = employees.Select(x => new Domain.Models.Employee()
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //});

            var response = new GetEmployeesResponse()
            {
                Data = mappedEmployees
            };
            
            return response;
        }
    }
}
