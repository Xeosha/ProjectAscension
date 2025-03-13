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
            var teams = await _readDbContext.Teams
                .Include(t => t.User) // Включаем владельца команды
                .Include(t => t.Characters) // Включаем персонажей команды
                    .ThenInclude(uc => uc.Character) // Детали базового персонажа
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    User = new UserInTeam(t.User.Id, t.User.UserName),
                    Name = t.Name,
                    Power = t.Power,
                    Members = t.Characters.Select(uc => new CharactersInTeam
                    {
                        Id = uc.Id,
                        Name = uc.Character.Name,
                    }).ToList()
                })
                .AsNoTracking() // Отключаем отслеживание изменений
                .ToListAsync(cancellationToken);


            _logger.LogInformation("Get all teams");

            return teams;
        }
    }
}
