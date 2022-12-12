using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class DeleteEmployeeRequest : IRequest<DeleteEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
}
