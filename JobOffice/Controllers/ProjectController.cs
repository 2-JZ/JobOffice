using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProject([FromBody] AddProjectRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{projectId}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int projectId)
        {
            var request = new DeleteProjectRequest()
            {
                Id = projectId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> GetProject([FromRoute] int projectId)
        {
            var request = new GetProjectRequest()
            {
                Id = projectId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }





    }
}
