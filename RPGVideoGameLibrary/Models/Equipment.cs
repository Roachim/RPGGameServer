using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Equipment
    {
        [Key]
        public int Equipment_Id { get; set; }
        public string Name { get; set; }
        //EquipmentType is tinyInt in database
        public int EquipmentType { get; set; }
        public EquipmentType EType { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        //references
        public ICollection<Inventory_Equipment> InventoryEquipments { get; set; }
    }
}
