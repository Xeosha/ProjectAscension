
using UserService.Domain.Models;

namespace UserService.Domain.Abstractions.Interfaces.Services
{
    public interface ITokenProvider
    {
        string GenerateAccessToken(User user);
    }
}
