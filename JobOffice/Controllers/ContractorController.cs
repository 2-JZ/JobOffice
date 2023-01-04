using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces;
using JobOffice.DataAcces.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractorController : ControllerBase
    {

        private readonly IMediator mediator;
        public ContractorController(IMediator mediator)
        {
            this.mediator = mediator ;

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddContractor([FromBody] AddContractorRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{contractorId}")]
        public async Task<IActionResult> DeleteContractor([FromRoute] int contractorId)
        {
            var request = new DeleteContractorRequest()
            {
                Id = contractorId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{contractorId}")]
        public async Task<IActionResult> GetContractorById([FromRoute] int contractorId)
        {
            var request = new GetContractorRequest()
            {
                Id = contractorId
            };
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetContractors([FromQuery] GetContractorsRequest request)
        {
            request = new GetContractorsRequest();
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("{contractorId}")]
        public async Task<IActionResult> PutContractor([FromBody] PutContractorRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

    }
}
