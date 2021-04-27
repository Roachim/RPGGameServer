using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Passive
    {
        public Passive()
        {
            CharactersPassives = new HashSet<CharactersPassive>();
        }

        public string PassiveName { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<CharactersPassive> CharactersPassives { get; set; }
    }
}
