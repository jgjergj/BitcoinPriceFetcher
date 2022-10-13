using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface IBitcoinPriceServices
    {
        public Task<BitcoinPrice> FetchBitcoinPrice(Source source);
    }
}
