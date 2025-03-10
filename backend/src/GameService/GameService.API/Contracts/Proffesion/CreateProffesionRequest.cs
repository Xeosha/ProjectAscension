

using GameService.Application.Commands.Proffesions.Create;

namespace GameService.API.Contracts.Proffesion
{
    public record CreateProffesionRequest
    (
        string name
    )
    {
        public CreateProffesionCommand ToCommand()
            => new CreateProffesionCommand(name);
    }
}
