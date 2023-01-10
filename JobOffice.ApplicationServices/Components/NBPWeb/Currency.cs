using Newtonsoft.Json;

namespace JobOffice.ApplicationServices.Components.NBPWeb
{
    public class Currency
    {
        //public string CurrencyName { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        //public string Code { get; set; }

        [JsonProperty("rates")]
        public RatesData Rates { get; set; }
    }
}
