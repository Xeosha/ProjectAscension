

using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Queries.Proffesions
{
    public class GetAllProffesionsHandler : IQueryHandler<List<ProffesionEntity>, GetAllProffesionsQuery>
    {
        public IProffesionsRepository _proffesionsRepository;
        public ILogger<GetAllProffesionsHandler> _logger;

        public GetAllProffesionsHandler(IProffesionsRepository proffesionsRepository, ILogger<GetAllProffesionsHandler> logger)
        {
            _proffesionsRepository = proffesionsRepository;
            _logger = logger;
        }
        
        public async Task<List<ProffesionEntity>> Handle(
            GetAllProffesionsQuery query,
            CancellationToken cancellationToken)
        {
            var entites = await _proffesionsRepository.GetAll();

            _logger.LogInformation("Get all proffesions");

            return entites.ToList();
        }
    }
}
