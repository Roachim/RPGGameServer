using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory_Equipment
    {
        //[Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inventory_Id { get; set; }

        //[Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Equipment_Id { get; set; }

        public int Quantity { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
