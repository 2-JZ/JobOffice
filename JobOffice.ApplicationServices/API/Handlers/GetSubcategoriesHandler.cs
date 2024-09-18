using AutoMapper;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.DataAcces.CQRS;
using MediatR;

public class GetSubcategoriesHandler : IRequestHandler<GetSubcategoriesRequest, GetSubcategoriesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetSubcategoriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetSubcategoriesResponse> Handle(GetSubcategoriesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetSubcategoriesQuery { ParentId = request.ParentCategoryId };
        var subcategories = await _queryExecutor.Execute(query);
        var mappedSubcategories = _mapper.Map<List<Category>>(subcategories);

        return new GetSubcategoriesResponse
        {
            Data = mappedSubcategories
        };
    }
}
