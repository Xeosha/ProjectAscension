using GameService.Application.Queries.UserCharacter;
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.API.Contracts.UserCharacter
{
    public record GetAllUserCharactersRequest
    (
        int Page,
        int PageSize
    ) : IQuery
    {
        public GetAllUserCharactersQuery ToQuery()
            => new(Page, PageSize);
    }
}
