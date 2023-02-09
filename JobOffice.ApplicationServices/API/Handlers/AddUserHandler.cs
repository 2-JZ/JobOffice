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
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IHashingPassword hashingPassword;
        private readonly IQueryExecutor queryExecutor;
        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor, IHashingPassword hashingPassword)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.hashingPassword = hashingPassword;
            this.queryExecutor = queryExecutor;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByUsernameQuery()
            {
                Username = request.Username
            };
            var isEmployeeInDb = await this.queryExecutor.Execute(query);
            if (isEmployeeInDb == null)
            {

                var user = this.mapper.Map<DataAcces.Entities.User>(request);
                var hashedPassword = this.hashingPassword.Hash(request.Password);
                user.Salt = hashedPassword[0];
                user.Password = hashedPassword[1];                
                var command = new AddUserCommand() { Parameter = user };
                var userFromDb = await this.commandExecutor.Execute(command);

                return new AddUserResponse()
                {
                    Data = this.mapper.Map<User>(userFromDb),
                };

            }
            else
            {
                return new AddUserResponse()
                {
                    Error =new ErrorModel(ErrorType.UserExist)
                };
            }
        }
    }
}
