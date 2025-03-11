using GameService.API.Contracts.Team;
using GameService.API.Extensions;
using GameService.Application.Commands.Team.Create;
using GameService.Application.Queries.Teams;
using GameService.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    [ApiController]
    [Route("/teams")]
    public class TeamController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(
        [FromServices] CreateTeamHandler handler,
        [FromBody] CreateTeamRequest request,
        CancellationToken cancellationToken)
        {
            var result = await handler.Handle(request.ToCommand(), cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult> Get(
        [FromServices] GetAllTeamsHandler handler,
        CancellationToken cancellationToken)
        {
            var query = new GetAllTeamsQuery();

            var response = await handler.Handle(query, cancellationToken);

            return Ok(response);
        }
    }

}
