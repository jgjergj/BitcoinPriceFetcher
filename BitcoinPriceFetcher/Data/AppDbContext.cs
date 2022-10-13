using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public string DbPath { get; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "BitcoinPriceFetcher.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitcoinPrice>()
                .HasIndex(entity => new { entity.TimeStamp, entity.ProviderName }, "IDX_TimeAndProvider").IsUnique();
        }

        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }
        public DbSet<Source> Sources { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
