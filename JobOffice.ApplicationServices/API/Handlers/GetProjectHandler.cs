using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Handlers
{
    public class GetProjectHandler : IRequestHandler<GetProjectRequest, GetProjectResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        public GetProjectHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetProjectResponse> Handle(GetProjectRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProjectQuery()
            {
                Id = request.Id,
            };
            var projectFromDb = await this.queryExecutor.Execute(query);
            return new GetProjectResponse()
            {
                Data = this.mapper.Map<Project>(projectFromDb)
            };

        }
    }
}
