using Microsoft.AspNetCore.Mvc;

namespace AscensionApp.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class AscensionAppController : ControllerBase
    {
        private readonly ILogger<AscensionAppController> _logger;

        public AscensionAppController(ILogger<AscensionAppController> logger)
        {
            _logger = logger;
        }
    }
}
