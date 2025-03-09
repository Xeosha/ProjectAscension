using GameService.API.Contracts.Character;
using GameService.API.Extensions;
using GameService.Application.Commands.Characters.Create;
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


    }
}
