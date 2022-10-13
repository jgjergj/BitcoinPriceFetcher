using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface ISourceProvider
    {
        public Task<BitcoinPrice> Fetch(string endpoint);
    }
}
