using AutoMapper;
using BitcoinPriceFetcher.DomainEntities;
using BitcoinPriceFetcher.Helpers;

namespace BitcoinPriceFetcher.Data.DTOs
{
    public class SourceDto
    {
        public string Name { get; set; }
        public string? Endpoint { get; set; }
        public string? DocumentationLink { get; set; }
    }

    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<Source, SourceDto>();
        }
    }
}
