
using GameService.CORE.Entities;
using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.CORE.Interfaces.Repositories
{
    public interface ICharactersRepository : IRepositoryCRUD<CharacterEntity>
    {
        Task<Result<CharacterEntity, Error>> UpdateMainInfo(Guid id, string name, string biography, uint age);
    }
}
