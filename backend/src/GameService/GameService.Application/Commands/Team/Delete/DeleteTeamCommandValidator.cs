using FluentValidation;


namespace GameService.Application.Commands.Team.Delete
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator()
        {
            RuleFor(d => d.TeamId).NotEmpty();
        }
    }
}
