using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RPGVideoGameAPI.Cryptography;
using RPGVideoGameAPI.Options;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Services
{
    public class AuthService
    {

        #region InstanceFields

        private readonly OnlineRPGContext _context;
        private readonly string _jwtSecret = Environment.GetEnvironmentVariable("JWT_Secret");

        #endregion

        #region Contructor

        public AuthService(OnlineRPGContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<AuthenticationResult> Login(string username, string password)
        {
            var encryptedPassword = Crypt.Encrypt(password);
            var profile =
                await _context.Profiles.SingleOrDefaultAsync(p => p.Name == username && p.Password == encryptedPassword);

            return profile == null ? new AuthenticationResult{Errors = new List<string>(){ "error occurred, incorrect user name or password" } } : GenerateToken(profile);
        }

        #endregion

        #region HelpMethods

        private AuthenticationResult GenerateToken(Profile profile)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(_jwtSecret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(JwtRegisteredClaimNames.Sub, profile.Uid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, profile.Email),
                    //new Claim(ClaimTypes.Role, profile.Role) ////OutComment When Roles have been implemented in the database
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }

        #endregion

    }
}
