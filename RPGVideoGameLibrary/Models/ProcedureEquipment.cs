using System;
using System.Collections.Generic;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public partial class ProcedureEquipment
    {
        public ProcedureEquipment()
        {
            CharacterChestNavigations = new HashSet<Character>();
            CharacterFeetNavigations = new HashSet<Character>();
            CharacterHandsNavigations = new HashSet<Character>();
            CharacterHeadNavigations = new HashSet<Character>();
            CharacterLeftHandNavigations = new HashSet<Character>();
            CharacterLegsNavigations = new HashSet<Character>();
            CharacterRightHandNavigations = new HashSet<Character>();
            InventoryEquipments = new HashSet<InventoryEquipment>();
        }

        public short EquipmentId { get; set; }
        public string Name { get; set; }
        public string EquipmentType { get; set; }
        public string Description { get; set; }
        public int? Hp { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }

        public virtual EquipmentType EquipmentTypeNavigation { get; set; }
        public virtual ICollection<Character> CharacterChestNavigations { get; set; }
        public virtual ICollection<Character> CharacterFeetNavigations { get; set; }
        public virtual ICollection<Character> CharacterHandsNavigations { get; set; }
        public virtual ICollection<Character> CharacterHeadNavigations { get; set; }
        public virtual ICollection<Character> CharacterLeftHandNavigations { get; set; }
        public virtual ICollection<Character> CharacterLegsNavigations { get; set; }
        public virtual ICollection<Character> CharacterRightHandNavigations { get; set; }
        public virtual ICollection<InventoryEquipment> InventoryEquipments { get; set; }
    }
}
