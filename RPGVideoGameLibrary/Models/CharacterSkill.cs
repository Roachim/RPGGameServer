using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class CharacterSkill
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string SkillName { get; set; }
    }
}
