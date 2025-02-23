using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Services;
using UserService.Domain.Abstractions.Interfaces.Services;

namespace UserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();  

            return services;
        }
    }
}
