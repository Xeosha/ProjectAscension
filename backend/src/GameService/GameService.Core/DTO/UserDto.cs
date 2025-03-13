

namespace GameService.CORE.DTO
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string UserName { get; init; } = default!;

        // Созданные команды
        public List<CharactersInTeam> Characters { get; init; } = new();
        public List<TeamInUserDto> Teams { get; init; } = new();
    }

    public record CharactersInTeam
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;

    }

    public record TeamInUserDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;

    }
}
