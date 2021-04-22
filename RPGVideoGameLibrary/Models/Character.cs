using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Character
    {
        
        public Character()
        {
            Passives = new HashSet<Passive>();
            Skills = new HashSet<Skill>();

        }
        [Key]
        public int Character_Id { get; set; }

        public int UID { get; set; }

        [Required]
        [StringLength(18)]
        public String CharacterName { get; set; }
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        
        public short? Head { get; set; }
        public short? Chest { get; set; }
        public short? Hands { get; set; }
        public short? Legs { get; set; }
        public short? Feet { get; set; }
        public short? Left_Hand { get; set; }
        public short? Right_Hand { get; set; }


        //references
        public Profile Profile { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<Passive> Passives { get; set; }
        public ICollection<Skill> Skills { get; set; }

        //equipment
        public Equipment HeadEquipment { get; set; }
        public Equipment ChestEquipment { get; set; }
        public Equipment HandsEquipment { get; set; }
        public Equipment LegsEquipment { get; set; }
        public Equipment FeetEquipment { get; set; }
        public Equipment Left_HandEquipment { get; set; }
        public Equipment Right_HandEquipment { get; set; }



    }
}
