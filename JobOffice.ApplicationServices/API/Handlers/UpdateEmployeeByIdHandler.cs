using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class UpdateEmployeeByIdHandler : IRequestHandler<UpdateEmployeeByIdRequest, UpdateEmployeeByIdResponse>
    {
        IMapper mapper;
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        public UpdateEmployeeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;

        }
        public async Task<UpdateEmployeeByIdResponse> Handle(UpdateEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var isEmployeeInDb = new GetEmployeeQuery()
            {
                Id = request.employeeId,

            };
            var employeeId = await queryExecutor.Execute(isEmployeeInDb);
            if (employeeId == null)
            {
                return null;
            }
            else
            {
                var employeeMappedFromRequest = this.mapper.Map<JobOffice.DataAcces.Entities.Employee>(request);
                var command = new UpdateEmployeeCommand()
                {
                    Parameter = employeeMappedFromRequest
                };
                var employeeFromDb = await this.commandExecutor.Execute(command);
                var mappedEmployee = this.mapper.Map<Domain.Models.Employee>(employeeFromDb);
                var response = new UpdateEmployeeByIdResponse()
                {
                    Data = mappedEmployee
                };
                return response;
            }
        }
    }
}
