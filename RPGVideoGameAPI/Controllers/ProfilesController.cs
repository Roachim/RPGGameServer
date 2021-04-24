using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;
using RPGVideoGameAPI.Services;

//using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<object>> ProfileName()
        {
            return await _userAccountService.GetAllProfiles();
        }
        //_context.Profiles.Select(p => new { p.Name, Characters = p.Characters.Select(c => new { c.CharacterName }) });


        
    }
}
