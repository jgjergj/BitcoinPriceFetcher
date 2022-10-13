using AutoMapper;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Helpers;
using BitcoinPriceFetcher.Services.Interfaces;
using Newtonsoft.Json;

namespace BitcoinPriceFetcher.Services.SourceProviders
{
    public class BitfinexProvider : ISourceProvider
    {
        private readonly IMapper _mapper;
        public BitfinexProvider(IMapper mapper)
        {
            _mapper = mapper;
        }

        private class BitfinexBitcoinPrice
        {
            [JsonProperty(PropertyName = "last_price")]
            public decimal Price { get; set; }
            
            [JsonProperty(PropertyName = "timestamp")]
            public string ProviderTimestamp { get; set; }
            
            public DateTime Timestamp => DateTimeHandler.ParseTimestamp(ProviderTimestamp.Split(".")[0]);
        }
        
        public async Task<BitcoinPrice> Fetch(string endpoint)
        {
            try
            {
                var resultString = await RequestHandler.GetDataFromProvider(endpoint);

                BitfinexBitcoinPrice btcPrice = JsonConvert.DeserializeObject<BitfinexBitcoinPrice>(resultString);

                return _mapper.Map<BitcoinPrice>(btcPrice);
                            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        private class BitfinexBitcoinPriceMappingProfile : Profile
        {
            public BitfinexBitcoinPriceMappingProfile()
            {
                CreateMap<BitfinexBitcoinPrice, BitcoinPrice>();
            }
        }
    }
}
