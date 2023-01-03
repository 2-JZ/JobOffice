using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{


    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public AddEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }
        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = this.mapper.Map<DataAcces.Entities.Employee>(request);
            var command = new AddEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await this.commandExecutor.Execute(command);

            return new AddEmployeeResponse()
            {
                Data = this.mapper.Map<Employee>(employeeFromDb),
            };
        }
    }
}
