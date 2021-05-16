using System;
using System.Collections.Generic;
using System.Text;

namespace RPGVideoGameLibrary.Interfaces
{
    public class IRPGDatabaseSettings
    {
        //Name of Collections in Database
        public string EquipmentCollection { get; set; }
        public string ItemsCollection { get; set; }
        public string PassivesCollection { get; set; }
        public string ProfilesCollection { get; set; }
        public string SkillsCollection { get; set; }
        //Connection String
        public string ConnectionString { get; set; }
        //name of Database
        public string DatabaseName { get; set; }

    }
}
