using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Source>()
                .HasData(
                    new Source
                    {
                        Id = 1,
                        Name = "Bitstamp",
                        Endpoint = "https://www.bitstamp.net/api/v2/ticker/btcusd/",
                        DocumentationLink = "https://www.bitstamp.net/api/#ticker"
                    },
                    new Source
                    {
                        Id = 2,
                        Name = "Bitfinex",
                        Endpoint = "https://api.bitfinex.com/v1/pubticker/btcusd",
                        DocumentationLink = "https://docs.bitfinex.com/v1/reference#rest-public-ticker"
                    }
                );
        }
    }

}
