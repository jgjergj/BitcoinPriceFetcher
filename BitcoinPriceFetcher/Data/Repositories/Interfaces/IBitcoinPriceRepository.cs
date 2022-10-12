using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories.Interfaces
{
    public interface IBitcoinPriceRepository
    {
        public List<BitcoinPrice> GetBitcoinPrices();
    }
}
