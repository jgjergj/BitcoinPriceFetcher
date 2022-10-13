using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories.Interfaces
{
    public interface ISourcesRepository
    {
        public Task<List<Source>> GetSources(CancellationToken cancellationToken);
    }
}
