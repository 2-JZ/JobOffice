using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces.CQRS.Queries;
using JobOffice.DataAcces.CQRS;
using MediatR;
using JobOffice.DataAcces.Entities;

public class GetCartByIdHandler : IRequestHandler<GetCartByIdRequest, GetCartByIdResponse>
{
    private readonly IQueryExecutor queryExecutor;
    private readonly IMapper mapper;

    public GetCartByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        this.queryExecutor = queryExecutor;
        this.mapper = mapper;
    }

    public async Task<GetCartByIdResponse> Handle(GetCartByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetShoppingCartByIdQuery { Id = request.CartId };
        var cart = await this.queryExecutor.Execute(query);

        return new GetCartByIdResponse
        {
            Data = this.mapper.Map<JobOffice.ApplicationServices.API.Domain.Models.ShoppingCart>(cart)
        };
    }
}
