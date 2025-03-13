using GameService.API.Contracts.UserCharacter;
using GameService.API.Extensions;
using GameService.Application.Commands.UserCharacter.Create;
using GameService.Application.Commands.UserCharacter.Delete;
using GameService.Application.Commands.UserCharacter.Update;
using GameService.Application.Queries.UserCharacter;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    [ApiController]
    [Route("/userCharacters")]
    public class UserCharacterContorller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(
        [FromQuery] GetAllUserCharactersRequest request,
        [FromServices] GetAllUserCharactersHandler handler,
        CancellationToken cancellationToken)
        {
            var query = request.ToQuery();

            var response = await handler.Handle(query, cancellationToken);

            return Ok(response);
        }

       [HttpPost]
       public async Task<ActionResult> Create(
       [FromServices] CreateUserCharacterHandler handler,
       [FromBody] CreateUserCharacterRequest request,
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
         [FromServices] DeleteUserCharacterHandler handler,
         CancellationToken cancellationToken)
        {
            var command = new DeleteUserCharacterCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(
        [FromRoute] Guid id,
        [FromServices] UpdateUserCharacterHandler handler,
        [FromBody] UpdateUserCharacterRequest request,
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
