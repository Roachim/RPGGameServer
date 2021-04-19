using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        public String CharacterName { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int UID { get; set; }
        public int Head { get; set; }
        public int Chest { get; set; }
        public int Hands { get; set; }
        public int Legs { get; set; }
        public int Feet { get; set; }
        public int Left_Hand { get; set; }
        public int Right_Hand { get; set; }
        //references

        public ICollection<Character_Passive> CharacterPassives { get; set; }
        public ICollection<Character_skill> CharacterSkills { get; set; }
        public Equipment HeadEquipment { get; set; }
        public Equipment ChestEquipment { get; set; }
        public Equipment HandsEquipment { get; set; }
        public Equipment LegsEquipment { get; set; }
        public Equipment FeetEquipment { get; set; }
        public Equipment Left_HandEquipment { get; set; }
        public Equipment Right_HandEquipment { get; set; }



    }
}
