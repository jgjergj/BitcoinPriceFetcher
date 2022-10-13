using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly IBitcoinPriceRepository _bitcoinPricesRepository;
        private readonly IBitcoinPriceServices _btcPriceServices;
        private readonly ILogger<BitcoinPriceController> _logger;
        
        public BitcoinPriceController(
            IBitcoinPriceRepository sourcesRepository,
            IBitcoinPriceServices btcPriceServices,
            ILogger<BitcoinPriceController> logger)
        {
            _bitcoinPricesRepository = sourcesRepository;
            _btcPriceServices = btcPriceServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<BitcoinPriceDto>> Get(CancellationToken cancellationToken)
        {
            return Ok(_bitcoinPricesRepository.GetBitcoinPrices(cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<BitcoinPriceDto>> FetchBtcPriceByProvider(Source request, CancellationToken cancellationToken)
        {
            var btcPrice = await _btcPriceServices.FetchBitcoinPrice(request, cancellationToken);
            
            return Ok(btcPrice);
        }
    }
}