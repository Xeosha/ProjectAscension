using GameService.Application.Commands.Team.Create;

namespace GameService.API.Contracts.Team
{
    public record CreateTeamRequest
    (
        string Name,
        Guid UserId,
        List<Guid>? CharacterIds
    )
    {
        public CreateTeamCommand ToCommand()
            => new CreateTeamCommand(
                Name, 
                UserId, 
                CharacterIds ?? new List<Guid>()
            );
    }
}
