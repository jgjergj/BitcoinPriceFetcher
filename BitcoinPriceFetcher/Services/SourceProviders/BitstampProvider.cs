using AutoMapper;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Helpers;
using BitcoinPriceFetcher.Services.Interfaces;
using Newtonsoft.Json;

namespace BitcoinPriceFetcher.Services.SourceProviders
{
    public class BitstampProvider : ISourceProvider
    {
        private readonly IMapper _mapper;
        public BitstampProvider(IMapper mapper)
        {
            _mapper = mapper;
        }

        private class BitstampBitcoinPrice
        {
            [JsonProperty(PropertyName = "last")]
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

                BitstampBitcoinPrice btcPrice = JsonConvert.DeserializeObject<BitstampBitcoinPrice>(resultString);

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
            long.TryParse(timestamp, out ticks);

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ticks);
            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
        }

        private class BitstampBitcoinPriceMappingProfile : Profile
        {
            public BitstampBitcoinPriceMappingProfile()
            {
                CreateMap<BitstampBitcoinPrice, BitcoinPrice>();
            }
        }
    }
}
