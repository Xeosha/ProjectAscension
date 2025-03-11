
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
    }
}
