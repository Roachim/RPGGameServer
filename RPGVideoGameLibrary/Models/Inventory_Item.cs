using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory_Item
    {
        [Key] public int Inventory_Id { get; set; }
        [Key] public string Item_name { get; set; }
        public int Quantity { get; set; }

        //references
        public Inventory Inventory { get; set; }
        public Item Item { get; set; }
    }
}
