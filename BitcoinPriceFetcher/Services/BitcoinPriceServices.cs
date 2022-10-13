using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.Services.Interfaces;

namespace BitcoinPriceFetcher.Services
{
    public class BitcoinPriceServices : IBitcoinPriceServices
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBitcoinPriceRepository _bitcoinPriceRepository;
        private readonly ISourcesRepository _sourcesRepository;
        private readonly IMapper _mapper;

        public BitcoinPriceServices(
            IServiceProvider serviceProvider,
            IBitcoinPriceRepository bitcoinPriceRepository,
            ISourcesRepository sourcesRepository,
            IMapper mapper
            )
        {
            _serviceProvider = serviceProvider;
            _bitcoinPriceRepository = bitcoinPriceRepository;
            _sourcesRepository = sourcesRepository;
            _mapper = mapper;
        }

        public async Task<BitcoinPriceDto> FetchBitcoinPrice(string sourceName, CancellationToken cancellationToken)
        {
            var source = await _sourcesRepository.GeByName(sourceName, cancellationToken);

            if (source != null)
            {
                Type sourceProviderType = Type.GetType("BitcoinPriceFetcher.Services.SourceProviders." + source.Name + "Provider");

                var sourceProvider = (ISourceProvider)ActivatorUtilities.CreateInstance(_serviceProvider, sourceProviderType);

                return await sourceProvider.FetchAndSave(source, cancellationToken);
            }

            return null;
        }

        public async Task<List<BitcoinPriceDto>> GetBitcoinPricesFromDb(CancellationToken cancellationToken)
        {
            var btcPricesList = await _bitcoinPriceRepository.GetBitcoinPrices(cancellationToken);

            return _mapper.Map<List<BitcoinPriceDto>>(btcPricesList);
        }
    }
}
