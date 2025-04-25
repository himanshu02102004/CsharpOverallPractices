using CRUD_TASK_WEB.DTOs;
using CRUD_TASK_WEB.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TASK_WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApiContext database;
        
        public LoginController(ApiContext dt)
        {
            database = dt;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Loginuser(LoginDto login)
        {
            var data = database.Users.FirstOrDefault(x => x.emailaddress == login.email);
            if (data == null)
            {
                return NotFound();
            }

            bool Valid = BCrypt.Net.BCrypt.Verify(login.password,data.password);
            if (!Valid)
            {
                return BadRequest("Invalid credentail");
            }
            return Ok("Login Successfully");

        }
    }
}
