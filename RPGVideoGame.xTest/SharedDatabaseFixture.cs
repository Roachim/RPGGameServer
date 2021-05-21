using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;
using Xunit;

namespace RPGVideoGame.xTest
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public DbConnection Connection { get; }

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(
                @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineRPG;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            Seed();

            Connection.Open();
        }

        public OnlineRPGContext CreateContext(DbTransaction transaction = null)
        {
            var context =
                new OnlineRPGContext(new DbContextOptionsBuilder<OnlineRPGContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;

        }

        /// <summary>
        /// The seed method instanciates the database and populates it with controlled data.
        /// </summary>
        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {

                    using (var context = new OnlineRPGContext())
                    {
                        //We delete the database and recreate it for clean slate
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        //Add new items
                        var one = new Item();
                        one.ItemName = "Potion";
                        one.Description = "Good for you";
                        one.Effect = "hels";
                        one.TypeId = 1;


                        context.AddRange(one);
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }

            
        }

        public void Dispose() => Connection.Dispose();

    }
}
