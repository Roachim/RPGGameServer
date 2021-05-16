using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGVideoGameAPI.Options;
using RPGVideoGameAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        #region InstanceFields

        private readonly AuthService _authService;

        #endregion

        #region Constructor

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] string username, string password)
        {
            var authResult = await _authService.Login(username, password);
            if (authResult.Errors != null)
            {
                return Unauthorized(new AuthFailedResponse
                {
                    Errors = authResult.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResult.Token
            });
        }

        #endregion
    }
}
