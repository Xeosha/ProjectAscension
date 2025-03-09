
using GameService.CORE.Entities;
using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using System.Linq.Expressions;

namespace GameService.CORE.Interfaces.Repositories
{
    public interface ICharactersRepository
    {
        Task<Result<CharacterEntity, Error>> GetById(Guid id);
        Task<IEnumerable<CharacterEntity>> GetAll();
        Task<IEnumerable<CharacterEntity>> Find(Expression<Func<CharacterEntity, bool>> predicate);
        Task<Result> Add(CharacterEntity character);
        Task<Result<CharacterEntity, Error>> UpdateMainInfo(Guid id, string name, string biography, uint age);
        Task<Result<CharacterEntity, Error>> Delete(Guid id);

    }
}
