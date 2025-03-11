using GameService.CORE.DTO;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GameService.Application.Queries.Characters
{
    public class GetAllCharactersHandler : IQueryHandler<List<CharacterDto>, GetAllCharactersQuery>
    {
        public IReadDbContext _readDbContext;
        public ILogger<GetAllCharactersHandler> _logger;
        public GetAllCharactersHandler(
            IReadDbContext readDbContext, 
            ILogger<GetAllCharactersHandler> logger)
        {
            _readDbContext = readDbContext;
            _logger = logger;
        }
        public async Task<List<CharacterDto>> Handle(
            GetAllCharactersQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _readDbContext.Characters.ToListAsync();

            _logger.LogInformation("Get all characters");

            return entities.ToList();
        }
    }
}
