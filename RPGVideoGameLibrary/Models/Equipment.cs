using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    //[Table("Equipment")]
    public class Equipment
    {
        public Equipment()
        {
            Characters1 = new HashSet<Character>();
            Characters2 = new HashSet<Character>();
            Characters3 = new HashSet<Character>();
            Characters4 = new HashSet<Character>();
            Characters5 = new HashSet<Character>();
            Characters6 = new HashSet<Character>();
            Characters7 = new HashSet<Character>();

        }
        [Key]
        public short Equipment_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        //EquipmentType is tinyInt in database
        public EquipmentType EquipmentType { get; set; }
        
        [StringLength(150)]
        public string Description { get; set; }
        public int? HP { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        //references
        public ICollection<Inventory_Equipment> InventoryEquipments { get; set; }

        public EquipmentType EType { get; set; }

        public ICollection<Character> Characters1 { get; set; }
        public ICollection<Character> Characters2 { get; set; }
        public ICollection<Character> Characters3 { get; set; }
        public ICollection<Character> Characters4 { get; set; }
        public ICollection<Character> Characters5 { get; set; }
        public ICollection<Character> Characters6 { get; set; }
        public ICollection<Character> Characters7 { get; set; }

    }

    
}
