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
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new PutContractorResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var query = new GetContractorQuery()
                {
                    Id = request.Id
                };
                var contractorFromQuery = await this.queryExecutor.Execute(query);
                if (contractorFromQuery == null)
                {
                    return new PutContractorResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
                {
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
    }
}
