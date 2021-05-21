using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;
using Xunit;

namespace RPGVideoGame.xTest
{
    public class AdminServiceTestItem : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }
        public AdminServiceTestItem(SharedDatabaseFixture fixture) => Fixture = fixture;

        [Fact]
        private void GetAllItems_Gets_Minimum_1_Item()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
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
}
