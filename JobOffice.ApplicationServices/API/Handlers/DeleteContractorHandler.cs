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
    public class DeleteContractorHandler : IRequestHandler<DeleteContractorRequest, DeleteContractorResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public DeleteContractorHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteContractorResponse> Handle(DeleteContractorRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "Developer")
            {
                return new DeleteContractorResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var isContractorInDb = new GetContractorQuery()
                {
                    Id = request.Id
                };
                var product = await queryExecutor.Execute(isContractorInDb);
                if (product == null)
                {
                    return new DeleteContractorResponse
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                else
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
    }
}
