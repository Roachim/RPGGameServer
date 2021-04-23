using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory_Item
    {
        //[Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inventory_Id { get; set; }

        //[Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Item_Name { get; set; }

        public int Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Item Item { get; set; }
    }
}
