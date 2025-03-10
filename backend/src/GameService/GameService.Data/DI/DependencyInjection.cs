using GameService.CORE.Interfaces.Repositories;
using GameService.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static CSharpFunctionalExtensions.Result;

namespace GameService.Data.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(
            this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDb(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICharactersRepository, CharactersRepository>();
            services.AddScoped<IProffesionsRepository, ProffesionRepository>();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameServiceDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("GameServiceDbContext")
                    ?? throw new ApplicationException("Missing database configuration");

                options.UseNpgsql(connectionString);
            });
            return services;
        }


    }
}
