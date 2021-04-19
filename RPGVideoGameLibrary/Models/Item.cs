using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Item
    {
        [Key] public string Item_Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        //references
        public ICollection<Inventory_Item> InventoryItems { get; set; }
    }
}
