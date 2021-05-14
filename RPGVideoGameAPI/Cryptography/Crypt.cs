using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPGVideoGameAPI.Cryptography
{
    public class Crypt
    {


        #region Methods

        public static string Encrypt(string data)
        {
            return Encoding.ASCII.GetString(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(data)));
        }

        #endregion

    }
}
