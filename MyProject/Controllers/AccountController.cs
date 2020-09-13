using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.Models;

namespace MyProject.Controllers
{
   
    public class AccountController : Controller
    {
        private List<Person> people = new List<Person>
        {
            new Person {Email = "admin2134.com", Password = "1234", Role = "aadmin"},
            new Person {Email = "user@1122.com", Password="1223",Role="usre"}
        };

        [HttpPost("/token")]
        public IActionResult Token(string username,string password)
        {
            var identity = GetIdntity(username, password);
            if(identity==null)
            {
                return BadRequest(new { errorText = "Invalid username or password!" });
            }

            var now = DateTime.UtcNow;
            //Создаём jwt - токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Json(response);
        }

        private ClaimsIdentity GetIdntity(string username, string password)
        {
            Person person = people.FirstOrDefault(p => p.Email == username && p.Password == password);
            if(person!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,person .Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                     ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}