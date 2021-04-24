using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            Equipment = new HashSet<Equipment>();
        }

        public byte EquipmentTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
