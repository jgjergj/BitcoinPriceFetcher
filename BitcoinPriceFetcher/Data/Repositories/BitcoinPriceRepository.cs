using AutoMapper;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class BitcoinPriceRepository : IBitcoinPriceRepository
    {
        private readonly IAppDbContext _appDbContext;

        public BitcoinPriceRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<BitcoinPrice>> GetBitcoinPrices(CancellationToken cancellationToken)
        {
            return await _appDbContext.BitcoinPrices.ToListAsync(cancellationToken);
        }

        public async Task<int> Create(BitcoinPrice bitcoinPrice, CancellationToken cancellationToken)
        {
            var entryExists = _appDbContext
                .BitcoinPrices
                .Where(e => e.TimeStamp == bitcoinPrice.TimeStamp && e.ProviderName == bitcoinPrice.ProviderName)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (entryExists == 0)
            {
                _appDbContext.BitcoinPrices.Add(bitcoinPrice);
                return await _appDbContext.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }
    }
}
