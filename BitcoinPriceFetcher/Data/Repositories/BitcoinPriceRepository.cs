using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class BitcoinPriceRepository: IBitcoinPriceRepository
    {
        public List<BitcoinPrice> GetBitcoinPrices()
        {
            using (var context = new AppDbContext())
            {
                var list = context.BitcoinPrices
                    .ToList();
                return list;
            }
        }
    }
}
