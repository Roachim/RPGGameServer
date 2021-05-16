using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGVideoGameAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        #region InstanceFields

        private UserAccountService _userAccountService;

        #endregion

        #region constructor

        public CharacterController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        #endregion



        #region Http

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<object>> GetAllCharacters()
        {

            return await _userAccountService.GetAllCharacters();
        }

        [HttpGet]
        [Route("{CharacterId}")]
        public async Task<object> OneProfile(int CharacterId)
        {
            return await _userAccountService.GetCharacter(CharacterId);
        }

        [HttpPost]
        [Route("CreateCharacter")]
        public async Task<string> AddNewCharacter([FromBody] Character character)
        {
            return await _userAccountService.AddNewCharacter(character);
        }

        [HttpPut]
        [Route("UpdateCharacter")]
        public async Task<string> UpdateCharacter([FromBody] Character character)
        {
            return await _userAccountService.UpdateCharacter(character);
        }


        [HttpDelete]
        [Route("DeleteCharacter/{characterId}")]
        public async Task<string> DeleteCharacter(int characterId)
        {
            return await _userAccountService.DeleteCharacter(characterId);
        }

        [HttpPost]
        [Route("AddItemToInventory")]
        public async Task<string> AddItemToInventory([FromBody]IEnumerable<InventoryItem> list)
        {
            return await _userAccountService.AddItemsToInventory(list);
        }


        [HttpPut]
        [Route("ChangeEquipment")]
        public async Task<string> ChangeEquipment([FromQuery] int characterId, [FromQuery] short equipmentId)
        {

            return await _userAccountService.ChangeEquipment(characterId, equipmentId);
        }

        #endregion
    }
}
