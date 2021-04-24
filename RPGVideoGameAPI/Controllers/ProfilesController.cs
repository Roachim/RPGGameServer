using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;

//using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly OnlineRPGContext _context;

        public ProfilesController()
        {
            
        }

        //[HttpGet]
        //public IEnumerable<object> ProfileName()
        //{
        //    return _context.Profiles.Select(p => new {p.Name, Characters = p.Characters.Select(c => new {c.CharacterName})});
        //}

        // GET: api/Profiles
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Profile>>> GetProfile()
        //{
        //    return await _context.Profile.ToListAsync();
        //}

        // GET: api/Profiles/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Profile>> GetProfile(int id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);

        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    return profile;
        //}

        //// PUT: api/Profiles/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProfile(int id, Profile profile)
        //{
        //    if (id != profile.UID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(profile).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProfileExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Profiles
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        //{
        //    _context.Profile.Add(profile);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProfile", new { id = profile.UID }, profile);
        //}

        //// DELETE: api/Profiles/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Profile>> DeleteProfile(int id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Profile.Remove(profile);
        //    await _context.SaveChangesAsync();

        //    return profile;
        //}

        //private bool ProfileExists(int id)
        //{
        //    return _context.Profile.Any(e => e.UID == id);
        //}
    }
}
