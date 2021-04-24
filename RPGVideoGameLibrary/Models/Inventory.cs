using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryEquipments = new HashSet<InventoryEquipment>();
            InventoryItems = new HashSet<InventoryItem>();
        }

        public int InventoryId { get; set; }
        public int MaximumSpace { get; set; }
        public int OccupiedSpace { get; set; }

        public virtual Character InventoryNavigation { get; set; }
        public virtual ICollection<InventoryEquipment> InventoryEquipments { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
