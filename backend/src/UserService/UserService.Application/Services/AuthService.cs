using Microsoft.AspNetCore.Identity;
using UserService.Domain.Abstractions.Interfaces.Services;
using UserService.Domain.Models;
using CSharpFunctionalExtensions;
using UserService.Domain.DTO;

namespace UserService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenProvider _jwtTokenProvider;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenProvider jwtTokenProvider
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<Result<string>> LoginPassword(LoginUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return Result.Failure<string>("User not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Result.Failure<string>("Invalid password");
            }

            var token = _jwtTokenProvider.GenerateAccessToken(user);
            return Result.Success(token);
        }

        public async Task<Result> Register(RegisterUserDto dto)
        {
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                return Result.Failure(string.Join(", ", errors));
            }

            return Result.Success();
        }
    }
}
