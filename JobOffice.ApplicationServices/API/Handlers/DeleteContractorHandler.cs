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
    public class DeleteContractorHandler : IRequestHandler<DeleteContractorRequest, DeleteContractorResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        public DeleteContractorHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.mapper=mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteContractorResponse> Handle(DeleteContractorRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteContractorCommand()
            {
                Id = request.Id
            };
            var contractorFromDb = await this.commandExecutor.Execute(command);
            
            return new DeleteContractorResponse()
            {
                Data = this.mapper.Map<Contractor>(contractorFromDb)

            };

            
        }
    }
}
