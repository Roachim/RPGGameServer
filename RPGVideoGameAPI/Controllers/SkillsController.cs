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
    public class SkillsController : ControllerBase
    {
        #region InstanceFields

        private readonly AdminService _adminService;


        #endregion

        #region Constructor

        public SkillsController(AdminService adminService)
        {
            _adminService = adminService;
        }


        #endregion


        #region Methods

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllSkills()
        {
            return await _adminService.GetAllSkills();
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<object> GetOneSkill([FromQuery] string skillName)
        {
            return await _adminService.GetSkill(skillName);
        }

        [HttpPost]
        [Route("CreateSkill")]
        [Authorize(Roles = "Admin")]
        public async Task<string> AddNewSkill([FromBody] Skill skill)
        {
            return await _adminService.AddNewSkill(skill);
        }

        [HttpPut]
        [Route("UpdateSkill")]
        [Authorize(Roles = "Admin")]
        public async Task<string> UpdateSkill([FromBody] Skill skill)
        {
            return await _adminService.UpdateSkill(skill);
        }


        [HttpDelete]
        [Route("DeleteSkill")]
        [Authorize(Roles = "Admin")]
        public async Task<string> DeleteSkill([FromQuery] string skillName)
        {
            return await _adminService.DeleteSkill(skillName);
        }
        #endregion
    }
}
