using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories.Interfaces
{
    public interface ISourcesRepository
    {
        public List<Source> GetSources();
    }
}
