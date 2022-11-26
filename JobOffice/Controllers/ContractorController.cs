using JobOffice.DataAcces;
using JobOffice.DataAcces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractorController : ControllerBase
    { 

        private readonly IRepository<Contractor> contractorRepository;
        public ContractorController(IRepository<Contractor> contractorRepository)
        {
            this.contractorRepository=contractorRepository;

        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Contractor> GetAllContractors() => this.contractorRepository.GetAll();

        [HttpGet]
        [Route("{ContractorId}")]
        public Contractor GetContractorById(int ContractorId) => this.contractorRepository.GetById(ContractorId);


    }
}
