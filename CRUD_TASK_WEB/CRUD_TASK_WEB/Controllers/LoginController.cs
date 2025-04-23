using CRUD_TASK_WEB.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TASK_WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {

            if(request.Usersname=="admin"  && request.Password == "1234")
            {
                return Ok(new { message = "login sucessful" });
            }


            return Unauthorized (new { message = "invalid" });
        }
    }
}
