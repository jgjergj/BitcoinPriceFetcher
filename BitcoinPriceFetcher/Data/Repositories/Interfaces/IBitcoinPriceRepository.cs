using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories.Interfaces
{
    public interface IBitcoinPriceRepository
    {
        public Task<List<BitcoinPriceDto>> GetBitcoinPrices(CancellationToken cancellationToken);
        public Task<int> Create(BitcoinPrice bitcoinPrice, CancellationToken cancellationToken);
    }
}
