using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Character_skill
    {
        [Key]
        public int Character_Id { get; set; }
        [Key]
        public string Skill_Name { get; set; }
        //references

        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
