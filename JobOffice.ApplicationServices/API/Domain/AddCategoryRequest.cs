using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddCategoryRequest : RequestBase, IRequest<AddCategoryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
        //public IFormFile? ImageData { get; set; }
        public byte[]? ImageData { get; set; }  // Store image as binary data


    }
}
