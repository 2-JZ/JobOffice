using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetEmployeesRequest : IRequest<GetEmployeesResponse>
    {
        //public string Login { get; set; }
    }
}
