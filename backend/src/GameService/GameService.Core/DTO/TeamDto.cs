
namespace GameService.CORE.DTO
{
    public record TeamDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public uint Power { get; init; } 

        public UserInTeam User { get; init; } = default!;
        public List<CharactersInTeam> Members { get; init; } = new();
    }
    public record UserInTeam(
        Guid UserId,
        string UserName
    );
}
