using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGVideoGameAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PassivesController : ControllerBase
    {
        #region InstanceFields

        private readonly AdminService _adminService;


        #endregion

        #region Constructor

        public PassivesController(AdminService adminService)
        {
            _adminService = adminService;
        }


        #endregion


        #region Methods

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllPassive()
        {
            return await _adminService.GetAllPassives();
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<object> GetOnePassive([FromQuery] string passiveName)
        {
            return await _adminService.GetPassive(passiveName);
        }

        [HttpPost]
        [Route("CreatePassive")]
        [Authorize(Roles = "Admin")]
        public async Task<string> AddNewPassive([FromBody] Passive passive)
        {
            return await _adminService.AddNewPassive(passive);
        }

        [HttpPut]
        [Route("UpdatePassive")]
        [Authorize(Roles = "Admin")]
        public async Task<string> UpdatePassive([FromBody] Passive passive)
        {
            return await _adminService.UpdatePassive(passive);
        }


        [HttpDelete]
        [Route("DeletePassive")]
        [Authorize(Roles = "Admin")]
        public async Task<string> DeletePassive([FromQuery] string passiveName)
        {
            return await _adminService.DeletePassive(passiveName);
        }
        #endregion
    }
}
