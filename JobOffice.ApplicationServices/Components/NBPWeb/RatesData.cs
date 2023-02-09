using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.ApplicationServices.Components.NBPWeb
{
    public class RatesData
    {
        [JsonProperty("mid")]
        public float Mid { get; set; }
    }
}
