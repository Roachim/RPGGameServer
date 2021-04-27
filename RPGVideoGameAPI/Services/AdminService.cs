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

            Item item = await _context.Items.FindAsync(itemName);

            if (item == null)
            {
                return "No item found";
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
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
