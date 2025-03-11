

namespace GameService.CORE.DTO
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string UserName { get; init; } = default!;

        // Связанные персонажи
        public List<UserCharacterDto> Characters { get; init; } = new();

        // Созданные команды
        public List<TeamDto> Teams { get; init; } = new();
    }
}
