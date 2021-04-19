using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public class Character_Passive
    {
        [Key]
        public int Character_Id { get; set; }
        [Key]
        public String Passive_Name { get; set; }

        //The below 2 properties are implemented to ensure the workings of the primary keys above
        //This is because it needs a pointer to the 2 rows of the tables that it joins
        //references
        public Character Character { get; set; }
        public Passive Passive { get; set; }
    }
}
