using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourcesController : ControllerBase
    {
        private readonly ISourcesRepository _sourcesRepository;
        private readonly ILogger<SourcesController> _logger;
        public SourcesController(ISourcesRepository sourcesRepository, ILogger<SourcesController> logger)
        {
            _sourcesRepository = sourcesRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Source>> Get()
        {
            return Ok(_sourcesRepository.GetSources());
        }
    }
}