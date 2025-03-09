
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Queries.Characters
{
    public class GetAllCharactersHandler : IQueryHandler<List<CharacterEntity>, GetAllCharactersQuery>
    {
        public ICharactersRepository _charactersRepository;
        public ILogger<GetAllCharactersHandler> _logger;
        public GetAllCharactersHandler(ICharactersRepository charactersRepository, ILogger<GetAllCharactersHandler> logger)
        {
            _charactersRepository = charactersRepository;
            _logger = logger;
        }
        public async Task<List<CharacterEntity>> Handle(
            GetAllCharactersQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _charactersRepository.GetAll();

            _logger.LogInformation("Get all characters");

            return entities.ToList();
        }
    }
}
