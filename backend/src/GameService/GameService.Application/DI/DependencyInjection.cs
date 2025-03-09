

using GameService.CORE.Interfaces.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using GameService.Application.Commands.Characters.Create;

namespace GameService.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.Scan(scan => scan.FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IQueryHandler<,>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

            services.AddScoped<IValidator<CreateCharacterCommand>, CreateCharacterCommandValidator>();

            return services;
        }
    }
}
