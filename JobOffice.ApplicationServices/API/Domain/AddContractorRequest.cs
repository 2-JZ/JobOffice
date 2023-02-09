using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{   
    public class AddContractorRequest : IRequest<AddContractorResponse>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string NIP { get; set; }
        public bool IsActive { get; set; }
        public string? country { get; set; }
    }
}
