using FluentValidation;
using GameService.CORE.Entities;

namespace GameService.Application.Commands.Team.Create
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.CharacterIds)
                .Must(ids => ids.Count <= TeamEntity.MAX_CHARACTERS)
                .WithMessage($"A team can have at most {TeamEntity.MAX_CHARACTERS} characters.")
                .When(cmd => cmd.CharacterIds.Any());
        }

    }
}
