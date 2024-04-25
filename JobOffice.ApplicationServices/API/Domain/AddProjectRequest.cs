using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class AddProjectRequest:IRequest<AddProjectResponse>
    {
        public string ProjectName { get; set; }
        public DateTime? ProjectStart { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ProjectEnd { get; set; }
        public string Adress { get; set; }
        
    }
}
