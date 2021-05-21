using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGVideoGameAPI.Controllers;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGame.Test
{
    
    [TestClass]
    public class ItemsControllerTests
    {
        /// <summary>
        /// A test to check whether the itemsController returns a list of objects
        /// </summary>
        [TestMethod]
        public void GetAllItems_Returns_A_Non_Empty_List()
        {
            //arrange
            var context = new OnlineRPGContext();
            
            var service = new AdminService(context);
            IEnumerable<object> Result;
            //act
            
            

            //assert

            throw new AssertFailedException();
        }

        [TestMethod]
        public void GetAllItems_Returns_Status_Code_200()
        {
            //arrange
           

            string HTTPCall = "";
            //act


            //assert
            throw new NotImplementedException();
        }
    }
}
