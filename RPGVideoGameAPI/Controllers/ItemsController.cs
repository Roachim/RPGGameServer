using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;
using RPGVideoGameAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGVideoGameAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        #region InstanceFields

        private readonly AdminService _adminService;


        #endregion

        #region Constructor

        public ItemsController(AdminService adminService)
        {
            _adminService = adminService;
        }


        #endregion


        #region Methods

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllItems()
        {
            return await _adminService.GetAllItems();
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<object> GetOneItem([FromQuery]string itemName)
        {
            return await _adminService.GetItem(itemName);
        }

        [HttpPost]
        [Route("CreateItem")]
        [Authorize(Roles = "Admin")]
        public async Task<string> AddNewItem([FromBody] Item item)
        {
            return await _adminService.AddNewItem(item);
        }

        [HttpPut]
        [Route("UpdateItem")]
        [Authorize(Roles = "Admin")]
        public async Task<string> UpdateItem([FromBody] Item item)
        {
            return await _adminService.UpdateItem(item);
        }


        [HttpDelete]
        [Route("DeleteItem")]
        [Authorize(Roles = "Admin")]
        public async Task<string> DeleteItem([FromQuery]string itemName)
        {
            return await _adminService.DeleteItem(itemName);
        }
        #endregion

        
    }
}
