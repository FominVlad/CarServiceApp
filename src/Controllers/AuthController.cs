using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CarServiceApp.Helpers;
using CarServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarServiceApp.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private AppDbContext dbContext { get; set; }
        private IConfiguration configuration { get; set; }

        public AuthController (AppDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetToken(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return BadRequest();

            ClaimsIdentity identity = GetIdentity(login, PasswordManager.GetPassHash(login, password));
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            DateTime nowDate = DateTime.UtcNow;
            IConfigurationSection authOptions = configuration.GetSection("AuthOptions");

            if (authOptions == null)
                throw new Exception("Configuration have not AuthOptions section!");

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: authOptions.GetSection("ISSUER")?.Value,
                    audience: authOptions.GetSection("AUDIENCE")?.Value,
                    notBefore: nowDate,
                    claims: identity.Claims,
                    expires: nowDate.Add(TimeSpan.FromMinutes(Convert.ToDouble(authOptions.GetSection("LIFETIME")?.Value))),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(authOptions.GetSection("KEY")?.Value)), 
                        SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Json(new { access_token = encodedJwt });
        }

        private ClaimsIdentity GetIdentity(string username, string passwordHash)
        {
            User user = dbContext.Users.FirstOrDefault(x => x.Login == username && x.Password == passwordHash);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, dbContext.Roles.FirstOrDefault(x => x.Id == user.RoleId).RoleName),
                    new Claim("userId", user.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
