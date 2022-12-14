using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class PutContractorHandler : IRequestHandler<PutContractorRequest, PutContractorResponse>
    {
        IQueryExecutor queryExecutor;
        ICommandExecutor commandExecutor;
        IMapper mapper;
        public PutContractorHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<PutContractorResponse> Handle(PutContractorRequest request, CancellationToken cancellationToken)
        {
            var query = new GetContractorQuery()
            {
                Id=request.Id
            };
            var contractorFromQuery = await this.queryExecutor.Execute(query);
            var mappedContractorFromRequest = this.mapper.Map<JobOffice.DataAcces.Entities.Contractor>(request);
            var command = new PutContractorCommand() { Parameter = mappedContractorFromRequest };
            var contractorCommand = await this.commandExecutor.Execute(command);
            return new PutContractorResponse()
            {
                Data = this.mapper.Map<Contractor>(contractorCommand)
            };

        }
    }
}
