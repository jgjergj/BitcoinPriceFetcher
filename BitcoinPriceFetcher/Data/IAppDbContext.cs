using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data
{
    public interface IAppDbContext
    {
        DbSet<BitcoinPrice> BitcoinPrices { get; set; }
        DbSet<Source> Sources { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
