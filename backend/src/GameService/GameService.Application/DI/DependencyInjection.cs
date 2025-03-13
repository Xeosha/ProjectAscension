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
using GameService.Application.Commands.Team.Delete;
using GameService.Application.Commands.Team.Update;
using GameService.Application.Commands.User.Create;
using GameService.Application.Commands.User.Delete;
using GameService.Application.Commands.User.Update;
using GameService.Application.Commands.UserCharacter.Create;
using GameService.Application.Commands.UserCharacter.Delete;
using GameService.Application.Commands.UserCharacter.Update;

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
            services.AddScoped<IValidator<UpdateTeamCommand>, UpdateTeamCommandValidator>();
            services.AddScoped<IValidator<DeleteTeamCommand>, DeleteTeamCommandValidator>();

            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
            services.AddScoped<IValidator<UpdateUserMainInfoCommand>, UpdateUserMainInfoCommandValidator>();

            services.AddScoped<IValidator<CreateUserCharacterCommand>, CreateUserCharacterCommandValidator>();
            services.AddScoped<IValidator<DeleteUserCharacterCommand>, DeleteUserCharacterCommandValidator>();
            services.AddScoped<IValidator<UpdateUserCharacterCommand>, UpdateUserCharacterCommandValidator>();


            return services;
        }
    }
}
