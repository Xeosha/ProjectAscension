

using GameService.CORE.DTO;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Queries.Proffesions
{
    public class GetAllProffesionsHandler : IQueryHandler<List<ProffesionDto>, GetAllProffesionsQuery>
    {
        public IReadDbContext _readDbContext;
        public ILogger<GetAllProffesionsHandler> _logger;

        public GetAllProffesionsHandler(IReadDbContext readDbContext, ILogger<GetAllProffesionsHandler> logger)
        {
            _readDbContext = readDbContext;
            _logger = logger;
        }
        
        public async Task<List<ProffesionDto>> Handle(
            GetAllProffesionsQuery query,
            CancellationToken cancellationToken)
        {

            var entities = await _readDbContext.Proffesions
                .Select(u => new ProffesionDto(u.Id, u.Name))
                .ToListAsync();

            _logger.LogInformation("Get all proffesions");

            return entities;
        }
    }
}
