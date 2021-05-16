using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public byte TypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
