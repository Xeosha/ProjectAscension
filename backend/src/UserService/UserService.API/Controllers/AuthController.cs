
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstractions.Interfaces.Services;
using UserService.Domain.DTO;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {   
            _authService = authService;
        }

        [HttpPost("/login-password")]
        public async Task<IActionResult> LoginPassword([FromBody] LoginUserDto dto)
        {
            var result = await _authService.LoginPassword(dto);

            if (result.IsSuccess)
            {
                return Ok(new { Token = result.Value });
            }

            return BadRequest(new { Message = result.Error });
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto request)
        {
            var result = await _authService.Register(request);

            if (result.IsSuccess)
            {
                return Ok(new { Message = "User registered successfully" });
            }

            return BadRequest(new { Message = result.Error });
        }

    }
}
