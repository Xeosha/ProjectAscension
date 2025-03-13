using GameService.CORE.DTO;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Queries.Users
{
    public class GetUsersHandler : IQueryHandler<List<UserDto>, GetUsersQuery>
    {
        public IReadDbContext _readDbContext;
        public ILogger<GetUsersHandler> _logger;

        public GetUsersHandler(IReadDbContext readDbContext, ILogger<GetUsersHandler> logger) {
            _readDbContext = readDbContext;
            _logger = logger;
        }

        public async Task<List<UserDto>> Handle(
            GetUsersQuery query,
            CancellationToken cancellationToken = default)
        {
            var entities = await _readDbContext.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    UserName = u.UserName,
                    Email = u.Email,
                    Characters = u.Characters
                        .Select(c => new CharactersInTeam
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList(),
                    Teams = u.Teams
                        .Select(c => new TeamInUserDto
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList()
                })
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Get all users");

            return entities; 
        }
    }
}
