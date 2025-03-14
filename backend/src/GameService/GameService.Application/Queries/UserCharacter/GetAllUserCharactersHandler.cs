using GameService.CORE.DTO;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GameService.CORE.Common;

namespace GameService.Application.Queries.UserCharacter
{
    public class GetAllUserCharactersHandler : IQueryHandler<PagedList<UserCharacterDto>, GetAllUserCharactersQuery>
    {
        public IReadDbContext _readDbContext;
        public ILogger<GetAllUserCharactersHandler> _logger;
        public GetAllUserCharactersHandler(IReadDbContext readDbContext, ILogger<GetAllUserCharactersHandler> logger)
        {
            _readDbContext = readDbContext;
            _logger = logger;
        }
        public async Task<PagedList<UserCharacterDto>> Handle(
            GetAllUserCharactersQuery query,
            CancellationToken cancellationToken)
        {
            var queryable = _readDbContext.UserCharacters
                .Include(s => s.Character)
                .Include(s => s.User)
                .Include(s => s.Proffesion)
                .Include(s => s.Team)
                .Select(t => new UserCharacterDto
                {
                    Id = t.Id,
                    User = new UserInUserCharacter(t.User.Id, t.User.UserName),
                    Character = new CharacterInUserCharacter(t.Character.Id, t.Character.Name),
                    Proffesion = t.Proffesion != null
                        ? new ProffesionInUserCharacter(t.Proffesion.Id, t.Proffesion.Name)
                        : null,
                    Team = t.Team != null
                        ? new TeamInUserCharacter(t.Team.Id, t.Team.Name)
                        : null,
                    Attack = t.Attack,
                    Defense = t.Defense,
                    Health = t.Health
                });

            var result = await queryable.ToPagedList(query.Page, query.PageSize, cancellationToken);

            _logger.LogInformation("Get all teams");

            return result;
        }
    }
}
