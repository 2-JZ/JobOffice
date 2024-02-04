using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetCategoryByIdRequest : RequestBase, IRequest<GetCategoryByIdResponse>
    {
        public int Id { get; set; }
    }
}
