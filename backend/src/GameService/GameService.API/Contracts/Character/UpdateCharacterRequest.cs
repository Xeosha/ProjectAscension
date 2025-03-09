using System.ComponentModel.DataAnnotations;

namespace GameService.API.Contracts.Character
{
    public class UpdateCharacterRequest
    {
        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }

        [Range(1, 150)]
        public uint Age { get; set; }

        [Range(1, 1000)]
        public uint BaseAttack { get; set; }

        [Range(1, 1000)]
        public uint BaseDefense { get; set; }

        [Range(1, 1000)]
        public uint BaseHealth { get; set; }
    }
}
