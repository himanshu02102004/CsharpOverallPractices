using Microsoft.IdentityModel.Tokens;
using System.CodeDom;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC_PART1
{
    public class JwtService
    {

        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }


        public string GenerateToken(string usernames, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,usernames),
                new Claim(ClaimTypes.Role,role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(

                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims : claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
    }
}
