using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RPGVideoGameLibrary.Enums;

namespace RPGVideoGameLibrary.Models
{
    public class EquipmentType
    {
        public EquipmentType()
        {
            Equipments = new HashSet<Equipment>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte EquipmentType_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
