using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.Components.HashingPassword;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IMediator mediator;
        private readonly IQueryExecutor queryExecutor;
        private readonly IHashingPassword passwordHash;
        private readonly IMapper mapper;
        public ValidateUserHandler(IMediator mediator, IQueryExecutor queryExecutor, IHashingPassword passwordHash, IMapper mapper)
        {
            this.mediator = mediator;
            this.queryExecutor = queryExecutor;
            this.passwordHash = passwordHash;
            this.mapper = mapper;
        }
        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByUsernameQuery()
            {
                Username = request.Username
            };
            var user = await this.queryExecutor.Execute(query);
            if (user != null)
            {
                var password = passwordHash.HashToCheck(request.Password, user.Salt);
                if (user.Password == password)
                {
                    var mappedUser = this.mapper.Map<Domain.Models.User>(user);
                    return new ValidateUserResponse()
                    {
                        Data = mappedUser
                    };
                }
                else
                {
                    return new ValidateUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.Unauthorized)
                    };
                }
            }
            else
            {
                return new ValidateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
        }
    }
}