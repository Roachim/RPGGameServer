using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Passive
    {
        public Passive()
        {
            CharactersPassives = new HashSet<CharactersPassife>();
        }

        public string PassiveName { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<CharactersPassife> CharactersPassives { get; set; }
    }
}
