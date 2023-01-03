﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class GetContractorRequest : IRequest<GetContractorResponse>
    {
        public int Id { get; set; }
    }
}
