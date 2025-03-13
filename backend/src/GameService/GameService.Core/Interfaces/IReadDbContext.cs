using GameService.CORE.Entities;

namespace GameService.CORE.Interfaces
{
    public interface IReadDbContext
    {
        public IQueryable<CharacterEntity> Characters { get; }

        public IQueryable<TeamEntity> Teams { get; }

        public IQueryable<UserEntity> Users { get; }

        public IQueryable<UserCharacterEntity> UserCharacters { get; }

        public IQueryable<ProffesionEntity> Proffesions { get; }
    }
}
