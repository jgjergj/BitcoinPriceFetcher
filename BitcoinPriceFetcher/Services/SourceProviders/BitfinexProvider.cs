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
            private long number;

            [JsonProperty(PropertyName = "last_price")]
            public decimal Price { get; set; }
            
            [JsonProperty(PropertyName = "timestamp")]
            public string ProviderTimestamp { get; set; }
            public DateTime Timestamp => ParseTimestamp(ProviderTimestamp);
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

        private static DateTime ParseTimestamp(string timestamp)
        {
            long ticks = 0;
            long.TryParse(timestamp.Split(".")[0], out ticks);

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ticks);
            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
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
