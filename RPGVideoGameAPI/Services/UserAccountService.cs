using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        #region Profiles

        

        /// <summary>
        /// Method for getting all profiles in the database
        /// getting only their id, name and email
        /// </summary>
        /// <returns>List of objects</returns>
        public async Task<IEnumerable<object>> GetAllProfiles()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Profiles.Select(p => new { p.Uid, p.Name, p.Email }).ToList);
            task.Start();
            IEnumerable<object> profileList = await task;
            return profileList;
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

        #endregion

        #region Characters


        /// <summary>
        /// Method for getting all Characters in the database
        /// </summary>
        /// <returns>List of objects</returns>
        public async Task<IEnumerable<object>> GetAllCharacters()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>
                (_context.Characters.Select(c => new 
                { c.CharacterId, c.CharacterName, c.Hp, c.Atk, c.Def, c.Uid, c.Head, c.Chest, c.Hands, c.Legs, c.Feet, c.LeftHand, c.RightHand }).ToList);
            task.Start();
            IEnumerable<object> charactersList = await task;
            return charactersList;
        }

        /// <summary>
        /// Get single Character
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns>single object</returns>
        public async Task<object> GetCharacter(int characterId)
        {
            Character character = await _context.Characters.FindAsync(characterId);

            return new { character.CharacterId, 
                character.CharacterName, 
                character.Hp, 
                character.Atk, 
                character.Def,
                character.Uid,
                character.Head, 
                character.Chest,
                character.Hands,
                character.Legs,
                character.Feet,
                character.LeftHand,
                character.RightHand };
        }

        /// <summary>
        /// Post a new character to the database
        /// </summary>
        /// <param name="character"></param>
        /// <returns>string with name and email of new profile</returns>
        public async Task<string> AddNewCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return $"Created character {character.CharacterName} on the profile {character.Uid}";
        }

        /// <summary>
        /// Updates character in database with new character that matches the id.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task<string> UpdateCharacter(Character character)
        {
            //check if character exist in database
            Profile exist = await _context.Profiles.FindAsync(character.Uid);
            if (exist == null) { return "No character found"; }

            //clear tracker and update character before returning message
            _context.ChangeTracker.Clear();
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
            return "character updated ";

        }

        /// <summary>
        /// Deletes a single character from database if found
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns>string telling whether or not character was deleted</returns>
        public async Task<string> DeleteCharacter(int characterId)
        {

            Character character = await _context.Characters.FindAsync(characterId);

            if (character == null) { return "No character found"; }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return $"Deleted character {character.CharacterName}, id={character.Uid}";
        }


        #endregion

        public async Task<string> AddItemsToInventory(IEnumerable<InventoryItem> list)
        {
            //Should many different items be insertable, or should several of a single item be insertable?
            //we can assume that the character id is the same as the id of the inventory that belong to them
            //Is there any way we can be sure though?
            //When a character is deleted their inventory should also get deleted

            string items = "";
            string characters = "";
            
            //If the item in that inventory already exists. Update the number instead, adding the unto the current amount with the new amount.
            foreach (var ii in list)
            {
                InventoryItem invItem = await _context.InventoryItems.FindAsync(ii.InventoryId, ii.ItemName);
                if (invItem != null)
                {
                    invItem.Quantity = invItem.Quantity + ii.Quantity;
                    _context.InventoryItems.Update(invItem);
                }
                else
                {
                    _context.InventoryItems.Add(ii);
                }
                await _context.SaveChangesAsync();

                items += ii.ItemName + ", ";
                Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Characters
                    .Select(c => new {c.CharacterName, c.CharacterId}).Where(e => e.CharacterId == ii.InventoryId).ToList);
                task.Start();
                characters += RemoveDump(task.Result.First().ToString()) + ", ";

                
            }

            //Reminder: Change items and character string to remove the last comma

            return $"The items {items} has been moved to the respective inventory for {characters}";
        }

        /// <summary>
        /// Input characterId and equipmentId.
        /// When changing equipment on a player:
        /// - check whether the type on equipment matches the slot on the player trying to equip it on: return bad request if not.
        /// 
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        /// <remarks>//get the character
        /// //get the equipment
        /// //get the equipment Type
        /// //check the equipment type via the equipment type table
        /// //find the corresponding slot on the character
        /// //put equipment in corresponding slot
        /// //override the database character with new updated character
        /// //save changes
        /// //if successful: return message showing name of character, equipment name and where it was equipped on character.</remarks>
        public async Task<string> ChangeEquipment(int characterId, short equipmentId)
        {
            

            Character character = await _context.Characters.FindAsync(characterId);
            Equipment equipment = await _context.Equipment.FindAsync(equipmentId);
            EquipmentType type = await _context.EquipmentTypes.FindAsync(equipment.EquipmentType);

            //insert equipment into correct slot
            if (type.Name == "Chest")
                character.Chest = equipment.EquipmentId;
            if (type.Name == "Hands")
                character.Hands = equipment.EquipmentId;
            if (type.Name == "Head")
                character.Head = equipment.EquipmentId;
            if (type.Name == "Feet")
                character.Feet = equipment.EquipmentId;
            if (type.Name == "Legs")
                character.Legs = equipment.EquipmentId;
            if (type.Name == "Left_Hand")
                character.LeftHand = equipment.EquipmentId;
            if (type.Name == "Right_Hand")
                character.RightHand = equipment.EquipmentId;

            //update character in database
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();

            //return message
            return $"Character {character.CharacterName} has equipped {equipment.Name} on their {type.Name}";
        }


        #region HelpMethods
        /// <summary>
        /// Specifically made to get a clearer string from characters in addItemsToInventory¨'
        /// Currently does not help at all
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string RemoveDump(string s)
        {
            //s = Regex.Replace(s, @"[\d]", String.Empty);
            s = s.Substring(18);

            string[] r = s.Split(',');
            return r[0];
        }

        #endregion


        #endregion




    }
}
