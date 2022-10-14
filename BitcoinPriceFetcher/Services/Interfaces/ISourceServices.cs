using BitcoinPriceFetcher.Data.DTOs;

namespace BitcoinPriceFetcher.Services.Interfaces
{
    public interface ISourceServices
    {
        public Task<List<SourceDto>> GetSources(CancellationToken cancellationToken);
    }
}
