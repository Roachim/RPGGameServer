using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Inventory_Equipment
    {
        [Key] public int Inventory_Id { get; set; }
        [Key] public int Equipment_Id { get; set; }
        public int Quantity { get; set; }
        //references
        public Inventory Inventory { get; set; }
        public Equipment Equipment { get; set; }
    }
}
