using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.UserCharacter.Delete
{
    public record DeleteUserCharacterCommand(Guid Id) : ICommand;
}
