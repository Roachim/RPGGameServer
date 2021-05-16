using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Item
    {
        public Item()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        public string ItemName { get; set; }
        public byte TypeId { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public virtual ItemType Type { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
