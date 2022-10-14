using BitcoinPriceFetcher_UI.Models;
using BitcoinPriceFetcher_UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitcoinPriceFetcher_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUiServices _uiServices;
       
        public HomeController(IUiServices uiServices)
        {
            _uiServices = uiServices;
        }

        public async Task<IActionResult> Index()
        {
            var sources = await _uiServices.GetSources();
            return View(sources);
        }

        public async Task<IActionResult> FetchPrice(string sourceName)
        {
            var btcPrice = await _uiServices.PostBitcoinPrice(sourceName);

            return Content(btcPrice.DisplayPrice);
        }

        public async Task<IActionResult> BitcoinPrices()
        {
            var btcPrices = await _uiServices.GetBitcoinPrices();
            return View(btcPrices);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}