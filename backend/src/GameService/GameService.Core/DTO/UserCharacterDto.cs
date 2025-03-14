

namespace GameService.CORE.DTO
{
    public record UserCharacterDto
    {
        public Guid Id { get; init; }

        public UserInUserCharacter User { get; init; }
        public CharacterInUserCharacter Character { get; init; }
        public ProffesionInUserCharacter? Proffesion { get; init; }
        public TeamInUserCharacter? Team{ get; init; }
        public uint Attack { get; init; }
        public uint Health { get; init; }
        public uint Defense { get; init; }
    }

    public record UserInUserCharacter(
        Guid Id,
        string Name
    );

    public record CharacterInUserCharacter(
        Guid Id,
        string Name
    );

    public record ProffesionInUserCharacter(
        Guid Id,
        string Name
    );
    public record TeamInUserCharacter(
        Guid Id,
        string Name
    );


}
