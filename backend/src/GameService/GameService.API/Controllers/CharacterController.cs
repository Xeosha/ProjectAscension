using GameService.API.Contracts.Character;
using GameService.API.Extensions;
using GameService.Application.Commands.Characters.Create;
using GameService.Application.Commands.Characters.Delete;
using GameService.Application.Commands.Characters.Update;
using GameService.Application.Queries.Characters;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    [ApiController]
    [Route("/characters")]
    public class CharacterController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(
         [FromServices] CreateCharacterHandler handler,
         [FromBody] CreateCharacterRequest request,
         CancellationToken cancellationToken)
        {
            var result = await handler.Handle(request.ToCommand(), cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult> Get(
        [FromServices] GetAllCharactersHandler handler,
        CancellationToken cancellationToken)
        {
            var query = new GetAllCharactersQuery();

            var response = await handler.Handle(query, cancellationToken);

            return Ok(response);
        }


        [HttpPut("{id:guid}/main-info")]
        public async Task<ActionResult> UpdateMainInfo(
         [FromRoute] Guid id,
         [FromServices] UpdateCharacterMainInfoHandler handler,
         [FromBody] UpdateCharacterMainInfoRequest request,
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
         [FromServices] DeleteCharacterHandler handler,
         CancellationToken cancellationToken)
        {
            var command = new DeleteCharacterCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }
    }
}
