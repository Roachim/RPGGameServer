using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Characters = new HashSet<Character>();
        }

        public int Uid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
