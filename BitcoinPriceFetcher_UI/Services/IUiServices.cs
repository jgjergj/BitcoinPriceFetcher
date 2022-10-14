using BitcoinPriceFetcher_UI.Models;

namespace BitcoinPriceFetcher_UI.Services
{
    public interface IUiServices
    {
        public Task<IEnumerable<Source>> GetSources();
        public Task<BitcoinPrice> PostBitcoinPrice(string source);
        public Task<IEnumerable<BitcoinPrice>> GetBitcoinPrices();
    }
}
