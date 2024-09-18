using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetSubcategoriesResponse : ResponseBase<List<Category>>
    {
        // This will contain the list of subcategories related to the provided parent category
    }
}
