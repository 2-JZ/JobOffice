using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.ErrorHandling;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetContractorHandler : IRequestHandler<GetContractorRequest, GetContractorResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetContractorHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetContractorResponse> Handle(GetContractorRequest request, CancellationToken cancellationToken)
        {
            var query = new GetContractorQuery()
            {
                Id = request.Id,
            };
            var contractorFromDb = await this.queryExecutor.Execute(query);
            if(contractorFromDb == null)
            {
                return new GetContractorResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetContractorResponse()
            {
                Data = this.mapper.Map<Contractor>(contractorFromDb)
            };
        }
    }
}
