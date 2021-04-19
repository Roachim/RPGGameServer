using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Passive
    {
        [Key] public string Passive_Name { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        //references
        public ICollection<Character_Passive> CharacterPassives { get; set; }
    }
}
