using AutoMapper;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain.Handlers
{
    public class AddContractorHandler : IRequestHandler<AddContractorRequest, AddContractorResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        public AddContractorHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;

        }

        public async Task<AddContractorResponse> Handle(AddContractorRequest request, CancellationToken cancellationToken)
        {
            var contractor = this.mapper.Map<Contractor>(request);
            var command = new AddContractorCommand() { Parameter = contractor };
            var contractorFromDb =  await this.commandExecutor.Execute(command);
            return new AddContractorResponse()
            {
                Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Contractor>(contractorFromDb),
            };
        }
    }
}
