using BitcoinPriceFetcher.Data.DTOs;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface ISourceProvider
    {
        public Task<BitcoinPriceDto> Fetch(string endpoint);
    }
}
