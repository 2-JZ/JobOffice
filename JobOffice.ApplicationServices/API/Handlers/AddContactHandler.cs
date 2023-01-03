using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class AddContactHandler: IRequestHandler<AddContactRequest, AddContactResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddContactHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;

        }
        public async Task<AddContactResponse> Handle(AddContactRequest request, CancellationToken cancellationToken)
        {

            var contact = this.mapper.Map<Contact>(request);
            var command = new AddContactCommand() { Parameter = contact };
            var contactFromDb = await this.commandExecutor.Execute(command);
            
            return new AddContactResponse()
            {
                Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Contact>(contactFromDb)
            };
        }
    }
}
