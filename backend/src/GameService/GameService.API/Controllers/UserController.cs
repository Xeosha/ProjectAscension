using GameService.API.Contracts.Team;
using GameService.API.Contracts.User;
using GameService.API.Extensions;
using GameService.Application.Commands.Team.Update;
using GameService.Application.Commands.User.Create;
using GameService.Application.Commands.User.Delete;
using GameService.Application.Commands.User.Update;
using GameService.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(
        [FromServices] GetUsersHandler handler,
        CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();

            var response = await handler.Handle(query, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
        [FromServices] CreateUserHandler handler,
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
        {
            var result = await handler.Handle(request.ToCommand(), cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(
         [FromRoute] Guid id,
         [FromServices] DeleteUserHandler handler,
         CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(
       [FromRoute] Guid id,
       [FromServices] UpdateUserMainInfoHandler handler,
       [FromBody] UpdateUserMainInfoRequest request,
       CancellationToken cancellationToken)
        {
            var command = request.ToCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }
    }
}
