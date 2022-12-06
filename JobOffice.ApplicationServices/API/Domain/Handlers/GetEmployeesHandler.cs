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
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.CQRS;

namespace JobOffice.ApplicationServices.API.Domain.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeesQuery();
            var employees = await this.queryExecutor.Execute(query);
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
