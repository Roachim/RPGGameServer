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
        /// <summary>
        /// Method for getting all profiles in the database
        /// getting only their id, name and email
        /// </summary>
        /// <returns>List of objects</returns>
        public async Task<IEnumerable<object>> GetAllProfiles()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Profiles.Select(p => new { p.Uid, p.Name, p.Email }).ToList);
            task.Start();
            IEnumerable<object> ProfileList = await task;
            return ProfileList;
        }


        /// <summary>
        /// Get single profile from id
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns>single object</returns>
        public async Task<object> GetProfile(int profileId)
        {
            Profile profile = await _context.Profiles.FindAsync(profileId);
            return new {profile.Uid, profile.Name, profile.Email};
        }


        /// <summary>
        /// Post a new profile to the database
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>string with name and email of new profile</returns>
        public async Task<string> AddNewProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
            return $"Created profile {profile.Name} with the email {profile.Email}";
        }

        public async Task<string> UpdateProfile(Profile profile)
        {
            Profile exist = await _context.Profiles.FindAsync(profile.Uid);
            if (exist == null) { return "No profile found"; }

            _context.ChangeTracker.Clear();
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
            return "Profile updated ";

        }


        /// <summary>
        /// Deletes a single profile from database if found
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns>string telling whether or not profile was deleted</returns>
        public async Task<string> DeleteProfile(int profileId)
        {

            Profile profile = await _context.Profiles.FindAsync(profileId);

            if (profile == null) { return "No profile found"; }
                
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return $"Deleted profile for {profile.Name} with the email {profile.Email}";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task<string> AddNewCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return $"Create character {character.CharacterName}";
        }

        /// <summary>
        /// no
        /// </summary>
        /// <param name="character"></param>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        public async Task<string> ChangeEquipment(Character character, short equipmentId)
        {
            Equipment equipment = await GetEquipment(equipmentId);
            //character.Legs = equipmentId;
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
            return $"{character.CharacterName} put on {equipment.Name}";
        }

        /// <summary>
        /// Get a single equipment
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns>equipment object</returns>
        public async Task<Equipment> GetEquipment(short equipmentId)
        {
            return await _context.Equipment.FindAsync(equipmentId);
        }
        #endregion




    }
}
