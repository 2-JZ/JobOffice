﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.API.Domain
{
    public class RequestBase
    {
        public string? AuthenticationName { get; set; }
        public string? AuthenticationRole { get; set; }
    }
}
