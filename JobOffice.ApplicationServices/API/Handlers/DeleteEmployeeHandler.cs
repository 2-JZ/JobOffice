using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }

        public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand()
            {
                Id = request.EmployeeId
            };
            //var employee = await this.commandExecutor.Execute(command);
            var employeeFromDb = await this.commandExecutor.Execute(command);
            var result = new DeleteEmployeeCommand(); //{ Parameter = employee };

            return new DeleteEmployeeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Employee>(employeeFromDb)

            };

        }
    }
}
