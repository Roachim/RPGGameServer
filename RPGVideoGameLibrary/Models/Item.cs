using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Inventory_Items = new HashSet<Inventory_Item>();
        }

        [Key]
        [StringLength(30)]
        public string Item_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string Effect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Item> Inventory_Items { get; set; }
    }
}
