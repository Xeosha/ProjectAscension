using GameService.Application.Commands.Team.Update;

namespace GameService.API.Contracts.Team
{
    public record UpdateTeamRequest
    (
        string Name,
        List<Guid> AddCharacters,
        List<Guid> DeleteCharacters
    )
    {
        public UpdateTeamCommand ToCommand(Guid id) =>
            new(id, Name, AddCharacters, DeleteCharacters);
    }
}
