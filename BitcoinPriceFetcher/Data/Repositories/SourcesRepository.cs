using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class SourcesRepository : ISourcesRepository
    {    
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
