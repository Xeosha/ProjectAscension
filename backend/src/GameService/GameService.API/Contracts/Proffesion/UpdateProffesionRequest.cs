using GameService.Application.Commands.Proffesions.Update;

namespace GameService.API.Contracts.Proffesion
{
    public record UpdateProffesionRequest
    (
        string name
    )
    {
        public UpdateProffesionCommand ToCommand(Guid id)
            => new(id, name);
    }
}
