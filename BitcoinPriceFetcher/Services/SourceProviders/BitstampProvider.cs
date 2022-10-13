using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Helpers;
using BitcoinPriceFetcher.Services.Interfaces;
using Newtonsoft.Json;

namespace BitcoinPriceFetcher.Services.SourceProviders
{
    public class BitstampProvider : ISourceProvider
    {
        private readonly IMapper _mapper;
        private readonly IBitcoinPriceRepository _repository;
        
        public BitstampProvider(
            IMapper mapper,
            IBitcoinPriceRepository bitcoinPriceRepository
            )
        {
            _mapper = mapper;
            _repository = bitcoinPriceRepository;
        }

        private class BitstampBitcoinPrice
        {
            [JsonProperty(PropertyName = "last")]
            public decimal Price { get; set; }
            
            [JsonProperty(PropertyName = "timestamp")]
            public string ProviderTimestamp { get; set; }
            
            public DateTime Timestamp => DateTimeHandler.ParseTimestamp(ProviderTimestamp);

            public string ProviderName { get; set; }
        }

        public async Task<BitcoinPriceDto> FetchAndSave(Source source, CancellationToken cancellationToken)
        {
            var resultString = await RequestHandler.GetDataFromProvider(source.Endpoint);

            BitstampBitcoinPrice btcPrice = JsonConvert.DeserializeObject<BitstampBitcoinPrice>(resultString);
            btcPrice.ProviderName = source.Name;

            var entity = _mapper.Map<BitcoinPrice>(btcPrice);
            var res = await _repository.Create(entity, cancellationToken);

            return _mapper.Map<BitcoinPriceDto>(btcPrice);            
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
