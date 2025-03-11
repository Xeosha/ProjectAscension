

namespace GameService.CORE.DTO
{
    public record UserCharacterDto
    {
        public Guid Id { get; init; }

        public Guid UserId { get; init; }
        public UserDto? User { get; init; }  // Навигационное свойство на пользователя

        public Guid CharacterId { get; init; }
        public CharacterDto? Character { get; init; }  // Навигационное свойство на персонажа

        public Guid ProffesionId { get; init; }
        public ProffesionDto? Proffesion { get; init; }  // Навигация на профессию

        public Guid? TeamId { get; init; }
        public TeamDto? Team { get; init; } // Навигация на команду (если персонаж в команде)
    }
}
