using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutContactRequest : IRequest<PutContactResponse>
    {
        public int Id { get; set; }
        public int Telephone { get; set; }
    }
}
