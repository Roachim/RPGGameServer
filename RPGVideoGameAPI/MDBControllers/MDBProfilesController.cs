using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RPGVideoGameAPI.MDBServices;
using RPGVideoGameLibrary.MDBModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGVideoGameAPI.MDBControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MDBProfilesController : ControllerBase
    {
        #region InstanceFields

        private readonly MDBUserService _mdbUserService;

        #endregion

        #region Constructor

        public MDBProfilesController(MDBUserService mdbUserService)
        {
            _mdbUserService = mdbUserService;
        }

        #endregion



        // GET: api/<MDBProfilesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<MDBProfile> Get()
        {
            return _mdbUserService.GetProfiles();
        }

        // GET api/<MDBProfilesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MDBProfilesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MDBProfilesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MDBProfilesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
