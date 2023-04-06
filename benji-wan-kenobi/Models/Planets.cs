using System.ComponentModel.DataAnnotations;

namespace benji_wan_kenobi.Models
{
    public class Planets
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Capital { get; set; }

        public string? Biome { get; set; }
    }
}
