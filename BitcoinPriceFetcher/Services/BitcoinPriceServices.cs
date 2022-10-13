using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Services.Interfaces;

namespace BitcoinPriceFetcher.Services
{
    public class BitcoinPriceServices : IBitcoinPriceServices
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBitcoinPriceRepository _bitcoinPriceRepository;
        private readonly IMapper _mapper;

        public BitcoinPriceServices(
            IServiceProvider serviceProvider,
            IBitcoinPriceRepository bitcoinPriceRepository,
            IMapper mapper
            )
        {
            _serviceProvider = serviceProvider;
            _bitcoinPriceRepository = bitcoinPriceRepository;
            _mapper = mapper;
        }

        public async Task<BitcoinPriceDto> FetchBitcoinPrice(Source source, CancellationToken cancellationToken)
        {
            //todo: add validations
            Type sourceProviderType = Type.GetType("BitcoinPriceFetcher.Services.SourceProviders." + source.Name + "Provider");

            var sourceProvider = (ISourceProvider)ActivatorUtilities.CreateInstance(_serviceProvider, sourceProviderType);

            return await sourceProvider.FetchAndSave(source, cancellationToken);
        }

        public async Task<List<BitcoinPriceDto>> GetBitcoinPricesFromDb(CancellationToken cancellationToken)
        {
            var btcPricesList = await _bitcoinPriceRepository.GetBitcoinPrices(cancellationToken);

            return _mapper.Map<List<BitcoinPriceDto>>(btcPricesList);
        }
    }
}
