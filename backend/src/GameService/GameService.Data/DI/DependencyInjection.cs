using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;
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
                .AddUnitOfWork()
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICharactersRepository, CharactersRepository>();
            services.AddScoped<IProffesionsRepository, ProffesionRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<IUserCharactersRepository, UserCharactersRepository>();

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WriteDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("GameServiceDbContext")
                    ?? throw new ApplicationException("Missing database configuration");

                options.UseNpgsql(connectionString);
            });

            services.AddDbContext<ReadDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("GameServiceDbContext")
                    ?? throw new ApplicationException("Missing database configuration");

                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IReadDbContext, ReadDbContext>();

            return services;
        }


    }
}
