

using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Team.Create
{
    public record CreateTeamCommand
    (
        string Name,
        Guid UserId,
        List<Guid> CharacterIds
    ) : ICommand;
}
