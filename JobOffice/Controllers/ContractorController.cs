using JobOffice.ApplicationServices.API.Domain;
using JobOffice.DataAcces;
using JobOffice.DataAcces.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractorController : ApiControllerBase
    {

        public ContractorController(IMediator mediator):base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddContractor([FromBody] AddContractorRequest request)
        {
            return this.HandleRequest<AddContractorRequest,AddContractorResponse>(request);
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BAD REQUEST U MAKING MISTAKE");
            //}
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpDelete]
        [Route("{contractorId}")]
        public async Task<IActionResult> DeleteContractor([FromRoute] int contractorId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST U MAKING MISTAKE");
            }
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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST U MAKING BIG MISTAKE");
            }
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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST U MAKING BIG MISTAKE");
            }
            request = new GetContractorsRequest();
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("{contractorId}")]
        public async Task<IActionResult> PutContractor([FromBody] PutContractorRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("BAD REQUEST U MAKING BIG MISTAKE");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

    }
}
