using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Skill
    {
        public Skill()
        {
            CharactersSkills = new HashSet<CharactersSkill>();
        }

        public string SkillName { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<CharactersSkill> CharactersSkills { get; set; }
    }
}
