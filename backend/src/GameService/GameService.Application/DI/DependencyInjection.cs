

using GameService.CORE.Interfaces.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using GameService.Application.Commands.Characters.Create;
using GameService.Application.Commands.Characters.Delete;
using GameService.Application.Commands.Characters.Update;

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
            services.AddScoped<IValidator<DeleteCharacterCommand>, DeleteCharacterCommandValidator>();
            services.AddScoped<IValidator<UpdateCharacterMainInfoCommand>, UpdateCharacterMainInfoCommandValidator>();

            return services;
        }
    }
}
