using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;
using Xunit;

namespace RPGVideoGame.xTest
{
    public class TestTest
    {

        [Fact]
        public void TestForTest()
        {
            Environment.SetEnvironmentVariable("SQLConnection", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineRPG;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (TransactionScope scope = new TransactionScope())
            {
                OnlineRPGContext dbContext = new OnlineRPGContext(new DbContextOptions<OnlineRPGContext>());

                var InvItems = from inItem in dbContext.InventoryItems
                    select inItem;

                foreach (InventoryItem inventoryItem in InvItems)
                {
                    dbContext.InventoryItems.Remove(inventoryItem);
                }

                var items = from i in dbContext.Items 
                    select i;

                foreach (Item item in items)
                {
                    dbContext.Items.Remove(item);
                }

                var itemTypes = from it in dbContext.ItemTypes
                    select it;

                foreach (ItemType item in itemTypes)
                {
                    dbContext.ItemTypes.Remove(item);
                }


                dbContext.SaveChanges();

                Assert.Equal(0, dbContext.ItemTypes.Count());
                Assert.Equal(0, dbContext.Items.Count());
                Assert.Equal(0, dbContext.InventoryItems.Count());
            }
        }


    }
}
