using JobOffice.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public EmployeesController(IMediator mediator, ILogger<EmployeesController> logger) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            return this.HandleRequest<GetEmployeesRequest, GetEmployeesResponse>(request);
        }

        [HttpGet]
        [Route("{employeeId}")]
        public Task<IActionResult> GetById([FromRoute] int employeeId)
        {
            var request = new GetEmployeeByIdRequest()
            {
                EmployeeId = employeeId
            };
            return this.HandleRequest<GetEmployeeByIdRequest, GetEmployeeByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{employeeId}")]
        public Task<IActionResult> Delete([FromRoute] int employeeId)
        {
            var request = new DeleteEmployeeRequest()
            {
                EmployeeId = employeeId
            };
            return this.HandleRequest<DeleteEmployeeRequest, DeleteEmployeeResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> Put([FromBody] UpdateEmployeeByIdRequest request)
        {
            return this.HandleRequest<UpdateEmployeeByIdRequest, UpdateEmployeeByIdResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return this.HandleRequest<AddEmployeeRequest, AddEmployeeResponse>(request);
        }
    }
}
