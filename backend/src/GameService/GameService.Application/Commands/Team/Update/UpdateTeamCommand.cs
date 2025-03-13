using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Team.Update
{
    public record UpdateTeamCommand
    (
        Guid Id,
        string Name,
        List<Guid> AddCharacters,
        List<Guid> DeleteCharacters
    ) : ICommand;
}
