using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {
        public SourcesRepository()
        {
            using (var context = new AppDbContext())
            {
                var sources = new List<Source>
                {
                    new Source { Id = 1, Name = "Bitstamp", Endpoint = "https://www.bitstamp.net/api/v2/ticker/btcusd/"},
                    new Source { Id = 2, Name = "Bitfinex", Endpoint = "https://api.bitfinex.com/v1/pubticker/btcusd"},
                };
                context.Sources.AddRange(sources);
                context.SaveChanges();
            }

        }
        public List<Source> GetSources()
        {
            using (var context = new AppDbContext())
            {
                var list = context.Sources
                    .ToList();
                return list;
            }
        }
    }
}
