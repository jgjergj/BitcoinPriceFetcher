using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories.Interfaces
{
    public interface IBitcoinPriceRepository
    {
        public Task<List<BitcoinPrice>> GetBitcoinPrices(CancellationToken cancellationToken);
        public Task<int> Create(BitcoinPrice bitcoinPrice, CancellationToken cancellationToken);
    }
}
