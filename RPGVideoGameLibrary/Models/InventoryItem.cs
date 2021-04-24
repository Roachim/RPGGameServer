using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class InventoryItem
    {
        public int InventoryId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Item ItemNameNavigation { get; set; }
    }
}
