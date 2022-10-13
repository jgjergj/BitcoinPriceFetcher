using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
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
        
        public async Task<BitcoinPriceDto> Fetch(string endpoint)
        {
                var resultString = await RequestHandler.GetDataFromProvider(endpoint);

                BitfinexBitcoinPrice btcPrice = JsonConvert.DeserializeObject<BitfinexBitcoinPrice>(resultString);

                //todo: save to db
                //_mapper.Map<BitcoinPrice>(btcPrice);
                
                return _mapper.Map<BitcoinPriceDto>(btcPrice);
        }

        private class BitfinexBitcoinPriceMappingProfile : Profile
        {
            public BitfinexBitcoinPriceMappingProfile()
            {
                CreateMap<BitfinexBitcoinPrice, BitcoinPrice>();
                CreateMap<BitfinexBitcoinPrice, BitcoinPriceDto>()
                    .ForMember(dto => dto.DisplayPrice, opt => opt.MapFrom(bp => PriceHandler.GetReadableValue(bp.Price)));
            }
        }
    }
}
