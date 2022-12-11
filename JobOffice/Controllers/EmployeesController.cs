using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);

        }
        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetById( int employeeId)
        {
            var request = new GetEmployeeByIdRequest()
            {
                EmployeeId = employeeId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        } 
    }
}
