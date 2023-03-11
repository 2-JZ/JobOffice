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
    public class PutContactHandler : IRequestHandler<PutContactRequest, PutContactResponse>
    {
        ICommandExecutor commandExecutor;
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public PutContactHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;

        }
        public async Task<PutContactResponse> Handle(PutContactRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new PutContactResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetContactByIdQuery()
                {
                    Id = request.Id
                };
                var queryContact = await this.queryExecutor.Execute(query);
                if (queryContact == null)
                {
                    return new PutContactResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
                {
                    var mappedContactFromRequest = this.mapper.Map<JobOffice.DataAcces.Entities.Contact>(request); // Shouldn't be there query in quotes?
                    var command = new PutContactCommand() { Parameter = mappedContactFromRequest };
                    var contactDb = await this.commandExecutor.Execute(command);
                    return new PutContactResponse()
                    {
                        Data = this.mapper.Map<Contact>(contactDb)
                    };
                }
            }
        }
    }
}
