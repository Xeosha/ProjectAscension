using GameService.CORE.Interfaces.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using GameService.Application.Commands.Characters.Create;
using GameService.Application.Commands.Characters.Delete;
using GameService.Application.Commands.Characters.UpdateMainInfo;
using GameService.Application.Commands.Proffesions.Delete;
using GameService.Application.Commands.Proffesions.Create;
using GameService.Application.Commands.Proffesions.Update;
using GameService.Application.Commands.Team.Create;

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

            services.AddScoped<IValidator<CreateProffesionCommand>, CreateProffesionCommandValidator>();
            services.AddScoped<IValidator<DeleteProffesionCommand>, DeleteProffesionCommandValidator>();
            services.AddScoped<IValidator<UpdateProffesionCommand>, UpdateProffesionCommandValidator>();


            services.AddScoped<IValidator<CreateTeamCommand>, CreateTeamCommandValidator>();


            return services;
        }
    }
}
