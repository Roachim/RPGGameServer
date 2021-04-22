using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Inventory_Items = new HashSet<Inventory_Item>();
            Inventory_Equipment = new HashSet<Inventory_Equipment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inventory_Id { get; set; }

        public int Maximum_Space { get; set; }

        public int Occupied_Space { get; set; }

        public virtual Character Character { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Item> Inventory_Items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Equipment> Inventory_Equipment { get; set; }


    }
}
