using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameService.Data.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(
            this IServiceCollection services, IConfiguration configuration)
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
