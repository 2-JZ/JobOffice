﻿using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.ApplicationServices.Components.NBPWeb;
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
    public class GetProjectsHandler : IRequestHandler<GetProjectsRequest, GetProjectsResponse>
    {
        IQueryExecutor queryExecutor;
        IMapper mapper;
        ICurrencyNbpConnector currencyNbpConnector;
        public GetProjectsHandler(IMapper mapper, IQueryExecutor queryExecutor, ICurrencyNbpConnector currencyNbpConnector)
        {
            this.mapper = mapper; 
            this.queryExecutor = queryExecutor;
            this.currencyNbpConnector = currencyNbpConnector;
        }
        public async Task<GetProjectsResponse> Handle(GetProjectsRequest request, CancellationToken cancellationToken)
        {
            var currency = this.currencyNbpConnector.Fetch("EUR");
            var query = new GetProjectsQuery();
            var projectsFromDb = await this.queryExecutor.Execute(query);
            return new GetProjectsResponse()
            {
                Data = this.mapper.Map<List<Project>>(projectsFromDb)
            };
        }
    }
}
