using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Character
    {
        public Character()
        {
            CharactersPassives = new HashSet<CharactersPassife>();
            CharactersSkills = new HashSet<CharactersSkill>();
        }

        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Uid { get; set; }
        public short? Head { get; set; }
        public short? Chest { get; set; }
        public short? Hands { get; set; }
        public short? Legs { get; set; }
        public short? Feet { get; set; }
        public short? LeftHand { get; set; }
        public short? RightHand { get; set; }

        public virtual Equipment ChestNavigation { get; set; }
        public virtual Equipment FeetNavigation { get; set; }
        public virtual Equipment HandsNavigation { get; set; }
        public virtual Equipment HeadNavigation { get; set; }
        public virtual Equipment LeftHandNavigation { get; set; }
        public virtual Equipment LegsNavigation { get; set; }
        public virtual Equipment RightHandNavigation { get; set; }
        public virtual Profile UidNavigation { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<CharactersPassife> CharactersPassives { get; set; }
        public virtual ICollection<CharactersSkill> CharactersSkills { get; set; }
    }
}
