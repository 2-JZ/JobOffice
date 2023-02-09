using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Serialization;

namespace JobOffice.ApplicationServices.Components.NBPWeb
{
    public class CurrencyNbpConnector : ICurrencyNbpConnector
    {
        private readonly RestClient restClient;
        public readonly string baseUrl = "http://api.nbp.pl/";
        public readonly string table = "A";
        public CurrencyNbpConnector()
        {
            this.restClient = new RestClient(baseUrl);

        }
        public async Task<Currency> Fetch(string code)
        {
            var request = new RestRequest("api/exchangerates/rates/A/EUR/", Method.Get);
            request.AddParameter("{WHYFUCKITSWORKING}",this.table);
            request.AddParameter("{WHYITSWORKING}", code);
            var queryResult = await restClient.ExecuteAsync(request);
            var currency = JsonConvert.DeserializeObject<Currency>(queryResult.Content);
            
            return currency;
        }
    }
}
