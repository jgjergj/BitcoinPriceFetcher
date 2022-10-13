using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly IBitcoinPriceServices _btcPriceServices;
        private readonly ILogger<BitcoinPriceController> _logger;
        
        public BitcoinPriceController(
            IBitcoinPriceServices btcPriceServices,
            ILogger<BitcoinPriceController> logger)
        {
            _btcPriceServices = btcPriceServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<BitcoinPriceDto>>> Get(CancellationToken cancellationToken)
        {            
            return Ok(await _btcPriceServices.GetBitcoinPricesFromDb(cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<BitcoinPriceDto>> FetchBtcPriceByProvider(string sourceName, CancellationToken cancellationToken)
        {
            var btcPrice = await _btcPriceServices.FetchBitcoinPrice(sourceName, cancellationToken);
            
            return Ok(btcPrice);
        }
    }
}