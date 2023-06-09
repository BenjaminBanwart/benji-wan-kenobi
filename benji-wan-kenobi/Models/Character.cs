﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace benji_wan_kenobi.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Motive { get; set; } = "Neutral";

        public string? Image { get; set; }

        [DisplayName("Appears In")]
        public string? AppearsIn { get; set; }
    }
}
