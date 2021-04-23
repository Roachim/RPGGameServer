using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Passive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passive()
        {
            this.Characters = new HashSet<Character>();
        }

        [Key]
        [StringLength(30)]
        public string Passive_Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string Effect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Character> Characters { get; set; }
    }
}
