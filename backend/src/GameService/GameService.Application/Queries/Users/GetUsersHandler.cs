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
            var entities = await _readDbContext.Users.ToListAsync();

            _logger.LogInformation("Get all users");

            return entities.ToList();
        }
    }
}
