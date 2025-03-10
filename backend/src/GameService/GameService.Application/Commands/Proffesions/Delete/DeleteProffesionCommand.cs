
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Proffesions.Delete
{

    public record DeleteProffesionCommand(Guid ProffesionId) : ICommand;
}
