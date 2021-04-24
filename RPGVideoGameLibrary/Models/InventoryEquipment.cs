using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class InventoryEquipment
    {
        public int InventoryId { get; set; }
        public short EquipmentId { get; set; }
        public int Quantity { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
