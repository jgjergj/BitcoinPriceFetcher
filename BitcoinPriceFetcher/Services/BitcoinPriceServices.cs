using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Services.Interfaces;

namespace BitcoinPriceFetcher.Services
{
    public class BitcoinPriceServices : IBitcoinPriceServices
    {
        private readonly IServiceProvider _serviceProvider;

        public BitcoinPriceServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<BitcoinPriceDto> FetchBitcoinPrice(Source source, CancellationToken cancellationToken)
        {
            //todo: add validations
            Type sourceProviderType = Type.GetType("BitcoinPriceFetcher.Services.SourceProviders." + source.Name + "Provider");

            var sourceProvider = (ISourceProvider)ActivatorUtilities.CreateInstance(_serviceProvider, sourceProviderType);

            return await sourceProvider.Fetch(source, cancellationToken);
        }
    }
}
