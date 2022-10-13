using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface ISourceProvider
    {
        public Task<BitcoinPriceDto> FetchAndSave(Source endpoint, CancellationToken cancellationToken);
    }
}
