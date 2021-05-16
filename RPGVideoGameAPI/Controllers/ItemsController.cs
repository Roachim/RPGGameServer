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
    [Authorize(Roles = "Admin")]
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
        [Authorize]
        public async Task<IEnumerable<object>> GetAllItems()
        {
            return await _adminService.GetAllItems();
        }

        [HttpGet]
        [Route("GetOne")]
        [Authorize]
        public async Task<object> GetOneItem([FromQuery]string itemName)
        {
            return await _adminService.GetItem(itemName);
        }

        [HttpPost]
        [Route("CreateItem")]
        public async Task<string> AddNewItem([FromBody] Item item)
        {
            return await _adminService.AddNewItem(item);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<string> UpdateItem([FromBody] Item item)
        {
            return await _adminService.UpdateItem(item);
        }


        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<string> DeleteItem([FromQuery]string itemName)
        {
            return await _adminService.DeleteItem(itemName);
        }
        #endregion

        
    }
}
