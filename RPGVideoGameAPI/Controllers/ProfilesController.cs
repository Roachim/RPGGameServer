using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;
using RPGVideoGameAPI.Services;

//using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        #region InstanceFields
        
        private readonly UserAccountService _userAccountService;

        #endregion
        #region Constructor

        public ProfilesController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }


        #endregion

        #region Http

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<object>> GetAllProfiles()
        {
            return await _userAccountService.GetAllProfiles();
        }
        
        [HttpGet]
        [Route("{profileId}")]
        public async Task<object> OneProfile(int profileId)
        {
            return await _userAccountService.GetProfile(profileId);
        }

        [HttpPost]
        [Route("CreateProfile")]
        public async Task<string> AddNewProfile([FromBody]Profile profile)
        {
            return await _userAccountService.AddNewProfile(profile);
        }

        [HttpPut]
        [Route("UpdateProfile")]
        public async Task<string> UpdateProfile([FromBody]Profile profile)
        {
            return await _userAccountService.UpdateProfile(profile);
        }
        

        [HttpDelete]
        [Route("DeleteProfile/{profileId}")]
        public async Task<string> DeleteProfile(int profileId)
        {
            return await _userAccountService.DeleteProfile(profileId);
        }


        #endregion


        //_context.Profiles.Select(p => new { p.Name, Characters = p.Characters.Select(c => new { c.CharacterName }) });

    }
}
