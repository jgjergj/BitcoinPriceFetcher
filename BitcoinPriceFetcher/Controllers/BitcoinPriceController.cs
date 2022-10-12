using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly IBitcoinPriceRepository _bitcoinPricesRepository;
        private readonly ILogger<BitcoinPriceController> _logger;
        public BitcoinPriceController(IBitcoinPriceRepository sourcesRepository, ILogger<BitcoinPriceController> logger)
        {
            _bitcoinPricesRepository = sourcesRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<BitcoinPrice>> Get()
        {
            return Ok(_bitcoinPricesRepository.GetBitcoinPrices());
        }
    }
}