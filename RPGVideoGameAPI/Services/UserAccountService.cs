using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Services
{
    /// <summary>
    /// Getting and managing profiles, their characters and all items, equipment, etc that is connected to them.
    /// Example: Editing information in a profile, deleting characters, removing items from a character, etc.
    /// </summary>
    public class UserAccountService
    {
        #region InstanceFields
        private OnlineRPGContext _context;

        #endregion

        #region Constructor
        public UserAccountService(OnlineRPGContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public async Task<IEnumerable<object>> GetAllProfiles()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Profiles.Select(p => new { p.Name }).ToList);
            IEnumerable<object> ProfileList = await task;
            return ProfileList;
        }

        public async Task<string> AddNewProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
            return $"Created profile {profile.Name} with the email {profile.Email}";
        }

        public async Task<string> AddNewCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return $"Create character {character.CharacterName}";
        }

        public async Task<string> ChangeEquipment(Character character, short equipmentId)
        {
            Equipment equipment = await GetEquipment(equipmentId);

            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
            return $"{character.CharacterName} put on {equipment.Name}";
        }

        public async Task<Equipment> GetEquipment(short equipmentId)
        {
            return await _context.Equipment.FindAsync(equipmentId);
        }
        #endregion




    }
}
