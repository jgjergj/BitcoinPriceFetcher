using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface IBitcoinPriceServices
    {
        public Task<BitcoinPriceDto> FetchBitcoinPrice(Source source);
    }
}
