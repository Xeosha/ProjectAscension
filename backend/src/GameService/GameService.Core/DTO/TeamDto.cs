
namespace GameService.CORE.DTO
{
    public record TeamDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;

        public Guid UserId { get; init; }

        // Список участников, которыми владеет эта команда
        public List<UserCharacterDto> Members { get; init; } = new();
    };
}
