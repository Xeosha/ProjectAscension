
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Proffesions.Create
{
    public record CreateProffesionCommand
    (
        string name
    ) : ICommand;
}
