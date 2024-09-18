using MediatR;
using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetSubcategoriesRequest :RequestBase, IRequest<GetSubcategoriesResponse>
    {
        public int ParentCategoryId { get; set; }  // The ID of the parent category for which we want to get subcategories
    }
}
