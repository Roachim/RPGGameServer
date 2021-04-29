using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Services
{

    /// <summary>
    /// Getting and managing items, equipment, skills, etc. 
    /// Used to add, delete, edit, etc. new things to the game.
    /// Example: Adding new boots, new skills, deleting existing items such as potions, etc. But not remove them from a specific player.
    /// </summary>
    public class AdminService
    {
        #region InstanceFields

        private readonly OnlineRPGContext _context;

        #endregion

        #region Constructor

        public AdminService(OnlineRPGContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Items

        public async Task<IEnumerable<object>> GetAllItems()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Items
                .Select(i => new {i.ItemName, i.Type, i.Effect, i.Description}).ToList);
            task.Start();
            IEnumerable<object> itemList = await task;
            return itemList;
        }

        /// <summary>
        /// Get single item from the item name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>single object</returns>
        public async Task<object> GetItem(string itemName)
        {
            Item item = await _context.Items.FindAsync(itemName);
            return new {item.ItemName, item.Type, item.Effect, item.Description};
        }


        /// <summary>
        /// Post a new item to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>string with name of new item</returns>
        public async Task<string> AddNewItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return $"Created item {item.ItemName}";
        }

        public async Task<string> UpdateItem(Item item)
        {
            Item exist = await _context.Items.FindAsync(item.ItemName);
            if (exist == null)
            {
                return "No item found";
            }

            _context.ChangeTracker.Clear();
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return "item updated ";

        }


        /// <summary>
        /// Deletes a single item from database if found
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>string telling whether or not item was deleted</returns>
        public async Task<string> DeleteItem(string itemName)
        {
            foreach (var i in _context.InventoryItems)
            {
                if (!String.Equals(i.ItemName, itemName, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                _context.InventoryItems.Remove(i);
                
                //_context.InventoryItems.Remove(_context.InventoryItems.Select(s => {s.ItemName == itemName}));
            }
            await _context.SaveChangesAsync();
            Item item = await _context.Items.FindAsync(itemName);
            
            if (item == null)
            {
                return "No item found";
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            //remove from join table first
            
            return $"Deleted item for {item.ItemName}";
        }

        #endregion

        #region Skills

        public async Task<IEnumerable<object>> GetAllSkills()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Skills.Select(s => new {s.SkillName, s.Effect, s.Description}).ToList);
            task.Start();
            IEnumerable<object> skillList = await task;
            return skillList;
        }

        /// <summary>
        /// Get single skill using the skill name
        /// </summary>
        /// <param name="skillName"></param>
        /// <returns>single object</returns>
        public async Task<object> GetSkill(string skillName)
        {
            Skill skill = await _context.Skills.FindAsync(skillName);
            return new {skill.SkillName, skill.Effect, skill.Description};
        }


        /// <summary>
        /// Post a new skill to the database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>string with name of new skill</returns>
        public async Task<string> AddNewSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return $"Created skill {skill.SkillName}";
        }

        public async Task<string> UpdateSkill(Skill skill)
        {
            Skill exist = await _context.Skills.FindAsync(skill.SkillName);
            if (exist == null)
            {
                return "No skill found";
            }

            _context.ChangeTracker.Clear();
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return $"skill {skill.SkillName} updated";

        }


        /// <summary>
        /// Deletes a single skill from database if found
        /// </summary>
        /// <param name="skillName"></param>
        /// <returns>string telling whether or not skill was deleted</returns>
        public async Task<string> DeleteSkill(string skillName)
        {
            //remove from join table
            foreach (var i in _context.CharactersSkills)
            {
                if (i.SkillName?.ToLower() != skillName.ToLower())
                {
                    continue;
                }

                _context.CharactersSkills.Remove(i);
            }
            await _context.SaveChangesAsync();

            Skill skill = await _context.Skills.FindAsync(skillName);

            if (skill == null)
            {
                return "No skill found";
            }
           
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return $"Deleted skill {skill.SkillName}";
        }

        #endregion

        #region Passives

        public async Task<IEnumerable<object>> GetAllPassives()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Passives
                .Select(p => new { p.PassiveName, p.Effect, p.Description }).ToList);
            task.Start();
            IEnumerable<object> passivesList = await task;
            return passivesList;
        }

        /// <summary>
        /// Get single passive using the passives name
        /// </summary>
        /// <param name="passiveName"></param>
        /// <returns>single object</returns>
        public async Task<object> GetPassive(string passiveName)
        {
            Passive passive = await _context.Passives.FindAsync(passiveName);
            return new { passive.PassiveName, passive.Effect, passive.Description };
        }


        /// <summary>
        /// Post a new passive to the database
        /// </summary>
        /// <param name="passive"></param>
        /// <returns>string with name of new passive</returns>
        public async Task<string> AddNewPassive(Passive passive)
        {
            _context.Passives.Add(passive);
            await _context.SaveChangesAsync();
            return $"Created passive {passive.PassiveName}";
        }

        public async Task<string> UpdatePassive(Passive passive)
        {
            Passive exist = await _context.Passives.FindAsync(passive.PassiveName);
            if (exist == null)
            {
                return "No item found";
            }

            _context.ChangeTracker.Clear();
            _context.Passives.Update(passive);
            await _context.SaveChangesAsync();
            return "passive updated ";

        }


        /// <summary>
        /// Deletes a single passive from database if found
        /// </summary>
        /// <param name="passiveName"></param>
        /// <returns>string telling whether or not passive was deleted</returns>
        public async Task<string> DeletePassive(string passiveName)
        {
            foreach (var i in _context.CharactersPassives)
            {
                if (i.PassiveName != passiveName)
                {
                    continue;
                }

                _context.CharactersPassives.Remove(i);
            }
            await _context.SaveChangesAsync();

            Passive passive = await _context.Passives.FindAsync(passiveName);

            if (passive == null)
            {
                return "No item found";
            }
            //remove from join table
            
            _context.Passives.Remove(passive);
            await _context.SaveChangesAsync();
            return $"Deleted {passive.PassiveName}";
        }

        #endregion

        #region Equipment

        public async Task<IEnumerable<object>> GetAllEquipment()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Equipment
                .Select(e => new { e.EquipmentId, e.Name, e.EquipmentType, e.Description, e.Hp, e.Atk, e.Def }).ToList);
            task.Start();
            IEnumerable<object> equipmentList = await task;
            return equipmentList;
        }

        /// <summary>
        /// Get single equipment using the equipments id
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns>single object</returns>
        public async Task<object> GetEquipment(short equipmentId)
        {
            Equipment equipment = await _context.Equipment.FindAsync(equipmentId);
            if (equipment == null)
                return null;
            
            return new { equipment.EquipmentId, equipment.Name, equipment.EquipmentType, equipment.Description, equipment.Hp, equipment.Atk, equipment.Def };
        }


        /// <summary>
        /// Post new equipment to the database
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns>string with name of the new equipment</returns>
        public async Task<string> AddNewEquipment(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return $"Created equipment {equipment.Name}";
        }

        public async Task<string> UpdateEquipment(Equipment equipment)
        {
            Equipment exist = await _context.Equipment.FindAsync(equipment.EquipmentId);
            if (exist == null)
            {
                return "No equipment found";
            }

            _context.ChangeTracker.Clear();
            _context.Equipment.Update(equipment);
            await _context.SaveChangesAsync();
            return "equipment updated ";

        }


        /// <summary>
        /// Deletes a single equipment from the database if found
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns>string telling whether or not equipment was deleted</returns>
        public async Task<string> DeleteEquipment(short equipmentId)
        {

            Equipment equipment = await _context.Equipment.FindAsync(equipmentId);

            if (equipment == null)
            {
                return "No equipment found";
            }

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return $"Deleted {equipment.Name}";
        }

        #endregion


        #region HelpMethods

        private async Task<string> UpdateAdminObject(Object obj)
        {
            
            if (obj is Skill)
            {
                Skill exist = await _context.Skills.FindAsync(obj);
                if (exist == null)
                {
                    return "No skill found";
                }

                _context.ChangeTracker.Clear();
                _context.Skills.Update(exist);
                await _context.SaveChangesAsync();
                return "skill updated ";
            }




            return null;
        }

        #endregion


        #endregion



    }
}
