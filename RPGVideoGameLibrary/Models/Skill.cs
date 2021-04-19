using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Skill
    {
        [Key] public string Skill_Name { get; set; }
        public string Description { get; set; }
        public string  Effect { get; set; }
        //references
        public ICollection<Character_skill> CharacterSkills { get; set; }
    }
}
