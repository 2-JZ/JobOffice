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

        public ContractorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddContractor([FromBody] AddContractorRequest request)
        {
            return this.HandleRequest<AddContractorRequest, AddContractorResponse>(request);
        }

        [HttpDelete]
        [Route("{contractorId}")]
        public Task<IActionResult> DeleteContractor([FromRoute] int contractorId)
        {
            var request = new DeleteContractorRequest()
            {
                Id = contractorId
            };
            return this.HandleRequest<DeleteContractorRequest, DeleteContractorResponse>(request);
        }

        [HttpGet]
        [Route("{contractorId}")]
        public Task<IActionResult> GetContractorById([FromRoute] int contractorId)
        {
            var request = new GetContractorRequest()
            {
                Id = contractorId
            };
            return this.HandleRequest<GetContractorRequest, GetContractorResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetContractors([FromQuery] GetContractorsRequest request)
        {
            return this.HandleRequest<GetContractorsRequest, GetContractorsResponse>(request);
        }
        
        [HttpPut]
        [Route("{contractorId}")]
        public Task<IActionResult> PutContractor([FromBody] PutContractorRequest request)
        {
            return this.HandleRequest<PutContractorRequest, PutContractorResponse>(request);
        }

    }
}
