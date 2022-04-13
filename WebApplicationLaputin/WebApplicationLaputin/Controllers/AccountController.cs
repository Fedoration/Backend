using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationLaputin.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using WebApplicationLaputin.DbContextBases;
using System.Security.Cryptography;
using System.Text;

namespace WebApplicationLaputin.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DbContextBase context;
        public AccountController(DbContextBase context)
        {
            this.context = context;
        }

        private string GetHashPassword(string password)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(password);

            var sb = new StringBuilder();
            foreach (var b in new MD5CryptoServiceProvider().ComputeHash(byteValue))
                sb.Append(b.ToString("x2"));

            var hashPassword = new StringBuilder();
            foreach (var b in new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(sb.ToString())))
                hashPassword.Append(b.ToString("x2"));
            return hashPassword.ToString();
        }

        [HttpPost("token")]
        public IActionResult Token(string username, string password)
        {
            string hashPassword = GetHashPassword(password);

            var identity = GetIdentity(username, hashPassword);
            if (identity == null)
            {
                return Unauthorized(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = this.context.Persons.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
