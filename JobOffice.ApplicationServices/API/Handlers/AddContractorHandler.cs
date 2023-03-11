using AutoMapper;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using JobOffice.DataAcces.Entities;
using MediatR;

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
            if (request.AuthenticationRole.ToString() == "Developer")
            {
                return new AddContractorResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            else
            {
                var contractor = this.mapper.Map<Contractor>(request);
                var command = new AddContractorCommand() { Parameter = contractor };
                var contractorFromDb = await this.commandExecutor.Execute(command);
                return new AddContractorResponse()
                {
                    Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.Contractor>(contractorFromDb),
                };
            }      
        }
    }
}
