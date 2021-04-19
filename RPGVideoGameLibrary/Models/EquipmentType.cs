using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RPGVideoGameLibrary.Enums;

namespace RPGVideoGameLibrary.Models
{
    public class EquipmentType
    {
        [Key]
        public int EquipmentType_Id { get; set; }
        public Equipment_Type Name { get; set; }
        //references
        public ICollection<Equipment> Equipments { get; set; }
    }
}
