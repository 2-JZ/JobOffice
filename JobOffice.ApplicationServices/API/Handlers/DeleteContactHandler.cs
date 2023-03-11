using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        public DeleteContactHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;

        }

        public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "Developer")
            {
                return new DeleteContactResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var isContactInDb = new GetContactByIdQuery()
                {
                    Id = request.Id
                };
                var contact = await queryExecutor.Execute(isContactInDb);
                if (contact == null)
                {
                    return new DeleteContactResponse
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
                {
                    var command = new DeleteContactCommand()
                    {
                        Id = request.Id,
                    };
                    var contactFromDb = await this.commandExecutor.Execute(command);

                    return new DeleteContactResponse()
                    {
                        Data = this.mapper.Map<Contact>(contactFromDb)
                    };
                }
            }
        }
    }
}
