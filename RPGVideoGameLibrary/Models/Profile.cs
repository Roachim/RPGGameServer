using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Profile
    {
        [Key] public int Uid { get; set; }
        public String Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //references
        public ICollection<Character> Characters { get; set; }


    }
}
