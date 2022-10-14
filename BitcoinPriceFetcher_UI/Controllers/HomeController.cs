using BitcoinPriceFetcher_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BitcoinPriceFetcher_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly HttpClient _httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            //_httpClient.BaseAddress = new Uri("https://localhost:5164/api/");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();

            var response = await _httpClient.GetStringAsync("http://localhost:5164/api/sources");
            //response.EnsureSuccessStatusCode();
            //var resultString = await response.Content.ReadAsStringAsync();
            List<Source> sources = JsonConvert.DeserializeObject<List<Source>>(response);

            return View(sources);
        }

        public async Task<IActionResult> FetchPrice(string sourceName)
        {
            //var requestContent = new StringContent(sourceName, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync("http://localhost:5164/api/bitcoinprice", requestContent);
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //var createdBtcPrice = JsonConvert.DeserializeObject<BitcoinPrice>(content);





            //URL
            var url = "http://localhost:5164/api/bitcoinprice";

            //Request
            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            //Headers
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Cache-Control", "no-cache");

            //Payload
            var payload = JsonConvert.SerializeObject(
                new
                {
                    Name = sourceName
                });
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            //Send
            var response = await _httpClient.SendAsync(request);

            //Handle response
            //if (response.IsSuccessStatusCode)
            var content = await response.Content.ReadAsStringAsync();
            var createdBtcPrice = JsonConvert.DeserializeObject<BitcoinPrice>(content);

            return Content(createdBtcPrice.DisplayPrice);
        }

        public async Task<IActionResult> BitcoinPrices()
        {
            using var client = new HttpClient();

            var response = await _httpClient.GetStringAsync("http://localhost:5164/api/bitcoinprice");
            //response.EnsureSuccessStatusCode();
            //var resultString = await response.Content.ReadAsStringAsync();
            List<BitcoinPrice> btcPrices = JsonConvert.DeserializeObject<List<BitcoinPrice>>(response);


            return View(btcPrices);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}