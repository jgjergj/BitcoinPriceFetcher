using AutoMapper;
using BitcoinPriceFetcher.Data.DTOs;
using BitcoinPriceFetcher.Data.Repositories.Interfaces;
using BitcoinPriceFetcher.Services.Interfaces;

namespace BitcoinPriceFetcher.Services
{
    public class SourceServices : ISourceServices
    {
        private readonly ISourcesRepository _sourcesRepository;
        private readonly IMapper _mapper;

        public SourceServices(
            ISourcesRepository sourcesRepository,
            IMapper mapper
            )
        {
            _sourcesRepository = sourcesRepository;
            _mapper = mapper;
        }

        public async Task<List<SourceDto>> GetSources(CancellationToken cancellationToken)
        {
            var sourcesList = await _sourcesRepository.GetSources(cancellationToken);

            return _mapper.Map<List<SourceDto>>(sourcesList);
        }
    }
}
