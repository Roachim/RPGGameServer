using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class CharactersPassife
    {
        public int CharacterId { get; set; }
        public string PassiveName { get; set; }

        public virtual Character Character { get; set; }
        public virtual Passive PassiveNameNavigation { get; set; }
    }
}
