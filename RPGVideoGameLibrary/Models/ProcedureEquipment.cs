using System;
using System.Collections.Generic;
using System.Text;

namespace RPGVideoGameLibrary.Models
{
    public partial class ProcedureEquipment
    {

        #region Properties

        public short Equipment_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Hp { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }

        #endregion


        #region Constructor

        public ProcedureEquipment()
        {
            
        }

        #endregion

        

        
    }
}
