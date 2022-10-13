﻿using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPriceFetcher.Data.Repositories
{
    public class BitcoinPriceRepository : IBitcoinPriceRepository
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public BitcoinPriceRepository(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<BitcoinPriceDto>> GetBitcoinPrices(CancellationToken cancellationToken)
        {
            var list = await _appDbContext.BitcoinPrices.ToListAsync(cancellationToken);
            return _mapper.Map<List<BitcoinPriceDto>>(list);
        }

        public async Task<int> Create(BitcoinPrice bitcoinPrice, CancellationToken cancellationToken)
        {
            _appDbContext.BitcoinPrices.Add(bitcoinPrice);
            return await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
