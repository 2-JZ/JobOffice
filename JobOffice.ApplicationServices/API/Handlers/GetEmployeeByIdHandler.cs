using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetEmployeeByIdHandler :IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };
            var employee = await this.queryExecutor.Execute(query);
            var mappedEmployee = this.mapper.Map<Domain.Models.Employee>(employee);
            var response = new GetEmployeeByIdResponse()
            {
                Data = mappedEmployee
            };
            return response;
        }
    }
}
