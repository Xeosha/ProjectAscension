
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Characters.Delete
{

    public record DeleteCharacterCommand(Guid CharacterId) : ICommand;
}
