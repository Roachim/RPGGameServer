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
    public class EquipmentController : ControllerBase
    {
        #region InstanceFields

        private readonly AdminService _adminService;


        #endregion

        #region Constructor

        public EquipmentController(AdminService adminService)
        {
            _adminService = adminService;
        }


        #endregion


        #region Methods

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllEquipment()
        {
            return await _adminService.GetAllEquipment();
        }

        //private enum EquipmentType { Head, Chest, Hands, Legs, Feet, RightHand, LeftHand }
        //make new GET() for getting all equipment matching specific type: example boots.--------------------------------------------<=
        [HttpGet]
        [Route("ByType")]
        public async Task<IEnumerable<object>> GetEquipmentByType([FromQuery] string equipmentType)
        {
            return await  _adminService.GetEquipmentByType(equipmentType);
        }

        [HttpGet]
        [Route("{equipmentId}")]
        public async Task<object> GetOneEquipment(short equipmentId)
        {
            return await _adminService.GetEquipment(equipmentId);
        }

        [HttpGet]
        [Route("UnusedEquipment")]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Object> GetUnusedEquipment()
        {
            return _adminService.GetUnusedEquipment();
        }

        [HttpPost]
        [Route("CreateEquipment")]
        [Authorize(Roles = "Admin")]
        public async Task<string> AddNewEquipment([FromBody] Equipment equipment)
        {
            return await _adminService.AddNewEquipment(equipment);
        }

        [HttpPut]
        [Route("UpdateEquipment")]
        [Authorize(Roles = "Admin")]
        public async Task<string> UpdateEquipment([FromBody] Equipment equipment)
        {
            return await _adminService.UpdateEquipment(equipment);
        }


        [HttpDelete]
        [Route("DeleteEquipment/{equipmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<string> DeleteEquipment(short equipmentId)
        {
            return await _adminService.DeleteEquipment(equipmentId);
        }
        #endregion
    }
}
