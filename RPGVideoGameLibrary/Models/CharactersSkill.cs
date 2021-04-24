using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class CharactersSkill
    {
        public int CharacterId { get; set; }
        public string SkillName { get; set; }

        public virtual Character Character { get; set; }
        public virtual Skill SkillNameNavigation { get; set; }
    }
}
