using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;
using Xunit;

namespace RPGVideoGame.xTest
{
    public class AdminServiceTest
    {
        protected AdminServiceTest(DbContextOptions<OnlineRPGContext> options)
        {
            Options = options;

            Seed();
        }

        protected DbContextOptions<OnlineRPGContext> Options { get; }
        /// <summary>
        /// The seed method instanciates the database again and populates it with controlled data.
        /// </summary>
        private void Seed()
        {
            using (var context = new OnlineRPGContext(Options))
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
        }

        [Fact]
        private void GetAllItems_Gets_Minimum_1_Item()
        {
            using (var context = new OnlineRPGContext(Options))
            {
                //arrange
                var service = new AdminService(context);
                //act
                IEnumerable<Object> result;
                result = service.GetAllItems().GetAwaiter().GetResult().ToList();
                //assert
                Assert.NotNull(result.ToList()[0]);

            }
        }
    }
}
