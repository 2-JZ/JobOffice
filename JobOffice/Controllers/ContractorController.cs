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
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        


    }
}
