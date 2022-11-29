using JobOffice.DataAcces;
using JobOffice.DataAcces.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace JobOffice.ApplicationServices.API.Domain.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IRepository<Employee> employeeRepository;
        public GetEmployeesHandler(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }
        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = this.employeeRepository.GetAll();
            var domainEmployees = employees.Select(x => new Domain.Models.Employee()
            {
                Id = x.Id,
                Name = x.Name
            });

        
            
            var response = new GetEmployeesResponse()
            {
                Data = domainEmployees.ToList()
            };
            
            return Task.FromResult(response);
        }
    }
}
