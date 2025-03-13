using GameService.API.Contracts.Proffesion;
using GameService.API.Contracts.Team;
using GameService.API.Extensions;
using GameService.Application.Commands.Proffesions.Delete;
using GameService.Application.Commands.Proffesions.Update;
using GameService.Application.Commands.Team.Create;
using GameService.Application.Commands.Team.Delete;
using GameService.Application.Commands.Team.Update;
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(
         [FromRoute] Guid id,
         [FromServices] UpdateTeamHandler handler,
         [FromBody] UpdateTeamRequest request,
         CancellationToken cancellationToken)
        {
            var command = request.ToCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(
         [FromRoute] Guid id,
         [FromServices] DeleteTeamHandler handler,
         CancellationToken cancellationToken)
        {
            var command = new DeleteTeamCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }
    }

}
