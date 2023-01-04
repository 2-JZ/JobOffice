using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutContractorRequest : IRequest<PutContractorResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<Project> Projects { get; set; }
        public int ContactId { get; set; }
    }
}
