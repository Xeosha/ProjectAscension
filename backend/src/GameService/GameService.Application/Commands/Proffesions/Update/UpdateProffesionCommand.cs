

using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Proffesions.Update
{

    public record UpdateProffesionCommand
    (
        Guid ProffesionId,
        string Name
    ) : ICommand;
}
