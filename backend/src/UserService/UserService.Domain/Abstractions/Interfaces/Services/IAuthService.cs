
using CSharpFunctionalExtensions;
using UserService.Domain.DTO;

namespace UserService.Domain.Abstractions.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<Result> Register(RegisterUserDto dto);    
        public Task<Result<string>> LoginPassword(LoginUserDto dto);

    }
}
