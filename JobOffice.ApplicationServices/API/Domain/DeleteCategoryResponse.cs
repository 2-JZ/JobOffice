using JobOffice.ApplicationServices.API.Domain.Models;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteCategoryResponse : ResponseBase<Category>
    {
        public int Id { get; set; }
    }
}
