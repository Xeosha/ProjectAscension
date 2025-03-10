
using GameService.API.Contracts.Proffesion;
using GameService.API.Extensions;
using GameService.Application.Commands.Proffesions.Create;
using GameService.Application.Commands.Proffesions.Delete;
using GameService.Application.Commands.Proffesions.Update;
using GameService.Application.Queries.Proffesions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    [ApiController]
    [Route("/proffesions")]
    public class ProffesionController : ControllerBase
    {
        private readonly ILogger<ProffesionController> _logger;

        public ProffesionController(ILogger<ProffesionController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> Create(
         [FromServices] CreateProffesionHandler handler,
         [FromBody] CreateProffesionRequest request,
         CancellationToken cancellationToken)
        {
            var result = await handler.Handle(request.ToCommand(), cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult> Get(
        [FromServices] GetAllProffesionsHandler handler,
        CancellationToken cancellationToken)
        {
            var query = new GetAllProffesionsQuery();

            var response = await handler.Handle(query, cancellationToken);

            return Ok(response);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(
         [FromRoute] Guid id,
         [FromServices] UpdateProffesionHandler handler,
         [FromBody] UpdateProffesionRequest request,
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
         [FromServices] DeleteProffesionHandler handler,
         CancellationToken cancellationToken)
        {
            var command = new DeleteProffesionCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }


    }
}
