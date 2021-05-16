using System;
using System.Collections.Generic;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class Role
    {
        public Role()
        {
            Profiles = new HashSet<Profile>();
        }

        public byte RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
