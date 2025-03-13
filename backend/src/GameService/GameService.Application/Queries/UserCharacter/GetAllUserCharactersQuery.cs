using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Queries.UserCharacter
{
    public record GetAllUserCharactersQuery
    (
        int Page,
        int PageSize
    ) : IQuery
    {
    }
}
