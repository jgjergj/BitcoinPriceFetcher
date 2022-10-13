using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        private readonly IAppDbContext _appDbContext;

        public SourcesRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Source>> GetSources(CancellationToken cancellationToken)
        {
            return await _appDbContext.Sources.ToListAsync(cancellationToken);            
        }
    }
}
