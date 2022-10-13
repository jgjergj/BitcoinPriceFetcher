using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
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
            
            public DateTime Timestamp => DateTimeHandler.ParseTimestamp(ProviderTimestamp);
        }

        public async Task<BitcoinPriceDto> Fetch(string endpoint)
        {
            try
            {
                var resultString = await RequestHandler.GetDataFromProvider(endpoint);

                BitstampBitcoinPrice btcPrice = JsonConvert.DeserializeObject<BitstampBitcoinPrice>(resultString);

                //todo: save to db
                //_mapper.Map<BitcoinPrice>(btcPrice);

                return _mapper.Map<BitcoinPriceDto>(btcPrice);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        private class BitstampBitcoinPriceMappingProfile : Profile
        {
            public BitstampBitcoinPriceMappingProfile()
            {
                CreateMap<BitstampBitcoinPrice, BitcoinPrice>();
                CreateMap<BitstampBitcoinPrice, BitcoinPriceDto>()
                    .ForMember(dto => dto.DisplayPrice, opt => opt.MapFrom(bp => PriceHandler.GetReadableValue(bp.Price)));
            }
        }
    }
}
