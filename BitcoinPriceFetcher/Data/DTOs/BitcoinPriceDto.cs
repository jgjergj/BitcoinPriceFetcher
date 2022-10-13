using AutoMapper;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Helpers;

namespace BitcoinPriceFetcher.Data.DTOs
{
    public class BitcoinPriceDto
    {
        public string ProviderName { get; set; }
        public string DisplayPrice { get; set; }
        public DateTime TimeStamp { get; set; }        
    }

    public class BitcoinPriceMappingProfile : Profile
    {
        public BitcoinPriceMappingProfile()
        {
            CreateMap<BitcoinPriceDto, BitcoinPrice>();
            CreateMap<BitcoinPrice, BitcoinPriceDto>()
                .ForMember(dto => dto.DisplayPrice, opt => opt.MapFrom(bp => PriceHandler.GetReadableValue(bp.Price)));
        }
    }
}
