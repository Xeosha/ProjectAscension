
using CSharpFunctionalExtensions;
using GameService.CORE.Common;

namespace GameService.CORE.Entities
{
    public class TeamEntity : BaseEntity
    {
        public static uint MAX_CHARACTERS = 3;
        public string Name { get; set; }
        public uint Power => CalculatePower();
        public List<UserCharacterEntity> Characters { get; set; } = new();

        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }

        private uint CalculatePower()
        {
            return (uint)Characters.Sum(c => c.Power);
        }

        private TeamEntity(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public static Result<TeamEntity, Error> Create(string name, Guid UserId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsRequired("Название команды обязательно");

            return new TeamEntity(name.Trim(), UserId);
        }

        public Result AddCharacter(UserCharacterEntity character)
        {
            if (Characters.Count > MAX_CHARACTERS)
                return Result.Failure("Team cannot have more than 3 characters.");

            if (Characters.Any(c => c.Id == character.Id))
                return Result.Failure("Персонаж уже в команде");

            if (character.TeamId.HasValue)
                return Result.Failure("Персонаж уже состоит в другой команде");

            character.JoinTeam(this);
            Characters.Add(character);

            return Result.Success();
        }

        // Удаление персонажа
        public Result RemoveCharacter(UserCharacterEntity character)
        {
            if (!Characters.Contains(character))
                return Result.Failure("Персонаж не найден в команде");

            Characters.Remove(character);
            character.LeaveTeam();

            return Result.Success();
        }



    }
}
