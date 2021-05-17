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
    /// Example: Adding new boots, new skills, deleting existing items such as potions, etc. But not remove them from one specific player.
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
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Items.Join(_context.ItemTypes, item => item.TypeId, type => type.TypeId, (item, type) => new {item, type.Type})
                .Select(i => new {i.item.ItemName, i.Type, i.item.Effect, i.item.Description}).ToList);
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
            ItemType type = await _context.ItemTypes.FirstAsync(t => t.TypeId == item.TypeId);
            return new {item.ItemName, type.Type, item.Effect, item.Description};
        }


        /// <summary>
        /// Post a new item to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>string with name of new item</returns>
        public async Task<string> AddNewItem(Item item)
        {
            await _context.Items.AddAsync(item);
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
            //starts a transaction
            var transaction = await _context.Database.BeginTransactionAsync();
            //remove from join table first
            foreach (var i in _context.InventoryItems)
            {
                if (!String.Equals(i.ItemName, itemName, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                _context.InventoryItems.Remove(i);
            }
            //save changes to join table
            await _context.SaveChangesAsync();

            Item item = await _context.Items.FindAsync(itemName);
            
            if (item == null)
            {
                return "No item found";
            }
            _context.Items.Remove(item);
            //save changes to item table
            await _context.SaveChangesAsync();
            

            //Commits the two changes done to the table at once
            await transaction.CommitAsync();

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
            var transaction = await _context.Database.BeginTransactionAsync();
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
            await transaction.CommitAsync();
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
            var transaction = await _context.Database.BeginTransactionAsync();
            //delete from join table
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

            
            _context.Passives.Remove(passive);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return $"Deleted {passive.PassiveName}";
        }

        #endregion

        #region Equipment

        public async Task<IEnumerable<object>> GetAllEquipment()
        {
            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Equipment.Join(_context.EquipmentTypes, equipment => equipment.EquipmentType, type => type.EquipmentTypeId, (equipment, type) => new {equipment, Type = type.Name})
                .Select(e => new { e.equipment.EquipmentId, e.equipment.Name, e.Type, e.equipment.Description, e.equipment.Hp, e.equipment.Atk, e.equipment.Def }).ToList);
            task.Start();
            IEnumerable<object> equipmentList = await task;
            return equipmentList;
        }

        public async Task<IEnumerable<object>> GetEquipmentByType(string equipmentType)
        {
            //Find the numberIndex in EquipmentType table corresponding to the string equipmentType from the parameter
            //Select all equipment from equipment table that has the given Index in their equipmentType
            //Return list with all the equipment found
            
            EquipmentType type =  await _context.EquipmentTypes.FirstOrDefaultAsync(e => e.Name == equipmentType);
            short index = type.EquipmentTypeId;
            

            Task<IEnumerable<object>> task = new Task<IEnumerable<object>>(_context.Equipment.Join(_context.EquipmentTypes, equipment => equipment.EquipmentType, et => et.EquipmentTypeId, (equipment, et) => new {equipment, Type = et.Name})
                .Select(e => new { e.equipment.EquipmentId, e.equipment.Name, e.Type, e.equipment.Description, e.equipment.Hp, e.equipment.Atk, e.equipment.Def }).Where(t => t.Type == equipmentType).ToList);

            task.Start();
                return await task;
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

            EquipmentType type = await _context.EquipmentTypes.FindAsync(equipment.EquipmentType);

            return new { equipment.EquipmentId, equipment.Name, Type = type.Name, equipment.Description, equipment.Hp, equipment.Atk, equipment.Def };
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
