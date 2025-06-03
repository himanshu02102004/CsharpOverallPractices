using CRUD_TASK_WEB.DTOs;
using CRUD_TASK_WEB.Models;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_TASK_WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApiContext database;
        private readonly IConfiguration configuration;
        public LoginController(ApiContext dt, IConfiguration configuration)
        {
            database = dt;
            this.configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Loginuser(LoginDto login)
        {
            var data = await database.Users.FirstOrDefaultAsync(x => x.emailaddress == login.email);
            if (data == null)
            {
                return NotFound();
            }

            bool Valid = BCrypt.Net.BCrypt.Verify(login.password, data.password);
            if (!Valid)
            {


                return NotFound("User not found");
            }

            /// jwt authentication

            if (string.IsNullOrEmpty(data.emailaddress))
            {
                return BadRequest("Email address is missing for user.");
            }


            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt: Subject"] ?? "default_subject"),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                      new Claim("ID",data.ID.ToString()),
                      new Claim("Email",data.emailaddress.ToString())

                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt: Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
                );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);  // TOKEN CREATED SUCCESFULY RETUNRN TOKEN

            return Ok(new
            {
                Token = tokenValue,
                User = new
                {
                    data.ID,
                    data.emailaddress

                }
            });
        }
    }   }
