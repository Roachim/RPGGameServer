using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory
    {
        [Key]
        public int Inventory_Id { get; set; }
        public int Character_Id { get; set; }
        public int Maximum_Space { get; set; }
        public int Occupied_Space { get; set; }
        public Character Character { get; set; }
        //references
        public ICollection<Inventory_Item> InventoryItems { get; set; }
        public ICollection<Inventory_Equipment> InventoryEquipments { get; set; }


    }
}
