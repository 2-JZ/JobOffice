using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class UpdateEmployeeByIdRequest: IRequest<UpdateEmployeeByIdResponse>
    {
        public int employeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int ContactId { get; set; }


    }
}
