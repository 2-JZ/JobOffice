using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public ProjectController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProject([FromBody] AddProjectRequest request)
        {
            return this.HandleRequest<AddProjectRequest, AddProjectResponse>(request);
        }

        [HttpDelete]
        [Route("{projectId}")]
        public Task<IActionResult> DeleteProject([FromRoute] int projectId)
        {
            var request = new DeleteProjectRequest()
            {
                Id = projectId
            };
            return this.HandleRequest<DeleteProjectRequest, DeleteProjectResponse>(request);
        }

        [HttpGet]
        [Route("{projectId}")]
        public Task<IActionResult> GetProject([FromRoute] int projectId)
        {
            var request = new GetProjectRequest()
            {
                Id = projectId
            };
            return this.HandleRequest<GetProjectRequest, GetProjectResponse>(request);

        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetProjects([FromQuery] GetProjectsRequest request)
        {
            return this.HandleRequest<GetProjectsRequest, GetProjectsResponse>(request);
        }

        [HttpPut]
        [Route("{projectId}")]
        public Task<IActionResult> PutProject([FromBody] PutProjectRequest request)
        {
            return this.HandleRequest<PutProjectRequest, PutProjectResponse>(request);
        }
    }
}
