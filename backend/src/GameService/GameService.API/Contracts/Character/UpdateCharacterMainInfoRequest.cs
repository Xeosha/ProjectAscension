

using GameService.Application.Commands.Characters.UpdateMainInfo;

namespace GameService.API.Contracts.Character
{

    public record UpdateCharacterMainInfoRequest
    (
        string name,
        string biography,
        uint age
    )
    {
        public UpdateCharacterMainInfoCommand ToCommand(Guid id) =>
            new(id, name, biography, age);
    }
}
