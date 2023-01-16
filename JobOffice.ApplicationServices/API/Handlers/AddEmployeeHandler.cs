using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.ApplicationServices.Components.HashingPassword;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{


    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IHashingPassword hashingPassword;
        public AddEmployeeHandler(
            ICommandExecutor commandExecutor,
            IMapper mapper,
            IQueryExecutor queryExecutor,
            IHashingPassword hashingPassword)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.hashingPassword = hashingPassword;

        }
        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByUsernameQuery()
            {
                Login = request.Login
            };
            var responseFromDb = await queryExecutor.Execute(query);
            if (responseFromDb == null)
            {


                var employee = this.mapper.Map<DataAcces.Entities.Employee>(request);
                var hashedPassword = hashingPassword.Hash(employee.Password);
                var hashedLogin = hashingPassword.Hash(employee.Login);
                employee.Login = hashedPassword[0];
                employee.Password = hashedPassword[1];
                var command = new AddEmployeeCommand() { Parameter = employee };
                var employeeFromDb = await this.commandExecutor.Execute(command);

                return new AddEmployeeResponse()
                {
                    Data = this.mapper.Map<Employee>(employeeFromDb),
                };
            }
            else
            {
                return new AddEmployeeResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }
    }
}
