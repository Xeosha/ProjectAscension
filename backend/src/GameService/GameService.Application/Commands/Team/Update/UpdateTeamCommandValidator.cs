using FluentValidation;

namespace GameService.Application.Commands.Team.Update
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
        }
    }
}
