using BitcoinPriceFetcher_UI.Models;
using Newtonsoft.Json;
using System.Text;

namespace BitcoinPriceFetcher_UI.Services
{
    public class UiServices : IUiServices
    {
        private static readonly string BaseApi = "http://localhost:5164/api/";
        private static readonly HttpClient _httpClient = new HttpClient();


        public async Task<IEnumerable<Source>> GetSources()
        {
            using var client = new HttpClient();

            var response = await _httpClient.GetStringAsync(BaseApi + "sources");
            List<Source> sources = JsonConvert.DeserializeObject<List<Source>>(response);

            return sources;
        }

        public async Task<BitcoinPrice> PostBitcoinPrice(string sourceName)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, BaseApi + "bitcoinprice");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Cache-Control", "no-cache");

            var payload = JsonConvert.SerializeObject(
                new
                {
                    Name = sourceName
                });
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var createdBtcPrice = JsonConvert.DeserializeObject<BitcoinPrice>(content);

            return createdBtcPrice;
        }

        public async Task<IEnumerable<BitcoinPrice>> GetBitcoinPrices()
        {
            var response = await _httpClient.GetStringAsync(BaseApi + "bitcoinprice");
            List<BitcoinPrice> btcPrices = JsonConvert.DeserializeObject<List<BitcoinPrice>>(response);

            return btcPrices;
        }
    }
}
