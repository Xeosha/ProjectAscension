using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Abstractions.Interfaces.Services;
using UserService.Domain.Models;

namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenProvider, JwtTokenProvider>();

            services.AddDbContext<UserServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(UserServiceDbContext)
                    ?? Environment.GetEnvironmentVariable(nameof(UserServiceDbContext))
                    ?? throw new ApplicationException("Missing postgres configuration")
                    ));
            });

            services.RegisterIdentity();

            return services;
        }

        private static void RegisterIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, Role>(options => { options.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<UserServiceDbContext>()
                .AddDefaultTokenProviders();
        }

    }
}