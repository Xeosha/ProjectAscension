using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Team.Delete
{

    public record DeleteTeamCommand(Guid TeamId) : ICommand;
}
