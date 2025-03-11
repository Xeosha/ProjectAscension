

using GameService.CORE.DTO;

namespace GameService.CORE.Interfaces
{
    public interface IReadDbContext
    {
        public IQueryable<CharacterDto> Characters { get; }
        public IQueryable<TeamDto> Teams { get; }
        public IQueryable<UserCharacterDto> UserCharacters { get; }
        public IQueryable<UserDto> Users { get; }
        public IQueryable<ProffesionDto> Proffesions { get; }
    }
}
