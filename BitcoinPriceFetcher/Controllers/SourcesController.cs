using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourcesController : ControllerBase
    {
        private readonly ISourceServices _sourceServices;
        private readonly ILogger<SourcesController> _logger;
        public SourcesController(ISourceServices sourcesServices, ILogger<SourcesController> logger)
        {
            _sourceServices = sourcesServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SourceDto>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _sourceServices.GetSources(cancellationToken));
        }
    }
}