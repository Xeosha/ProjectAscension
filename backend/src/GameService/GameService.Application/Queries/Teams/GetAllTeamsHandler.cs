using GameService.CORE.DTO;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Queries.Teams
{
    public class GetAllTeamsHandler : IQueryHandler<List<TeamDto>, GetAllTeamsQuery>
    {
        public IReadDbContext _readDbContext;
        public ILogger<GetAllTeamsHandler> _logger;
        public GetAllTeamsHandler(IReadDbContext readDbContext, ILogger<GetAllTeamsHandler> logger)
        {
            _readDbContext = readDbContext;
            _logger = logger;
        }
        public async Task<List<TeamDto>> Handle(
            GetAllTeamsQuery query,
            CancellationToken cancellationToken)
        {
            var entities = await _readDbContext.Teams.ToListAsync();

            _logger.LogInformation("Get all teams");

            return entities.ToList();
        }
    }
}
