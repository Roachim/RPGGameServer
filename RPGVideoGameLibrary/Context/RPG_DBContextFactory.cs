using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace RPGVideoGameLibrary.Context
{
    public class RPG_DBContextFactory : IDbContextFactory<RPG_DBContext>
    {
        public RPG_DBContext Create()
        {
            return new RPG_DBContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
