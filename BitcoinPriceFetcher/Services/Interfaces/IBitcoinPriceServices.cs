using BitcoinPriceFetcher.Data.DTOs;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface IBitcoinPriceServices
    {
        public Task<BitcoinPriceDto> FetchBitcoinPrice(string sourceName, CancellationToken cancellationToken);
        public Task<List<BitcoinPriceDto>> GetBitcoinPricesFromDb(CancellationToken cancellationToken);
    }
}
