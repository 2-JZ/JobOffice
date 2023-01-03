using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public DeleteContactHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;

        }

        public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
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
