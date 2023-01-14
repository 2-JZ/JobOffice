﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class PutProjectRequest : IRequest<PutProjectResponse>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ProjectStart { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ProjectEnd { get; set; }
        public string Adress { get; set; }

    }
}
