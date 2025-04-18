using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContrext _userContext;

        public UsersController(UserContrext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            return await _userContext.Users.ToListAsync();
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<Users>> GetUser(int ID)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.ID == ID);
            if (user == null)
                return NotFound("User not found");

            return user;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<string>> AddUser([FromBody] Users users)
        {
            _userContext.Users.Add(users);
            await _userContext.SaveChangesAsync();
            return Ok("User Added Successfully");
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<string>> UpdateUser([FromBody] Users users)
        {
            _userContext.Entry(users).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
            return Ok("User Updated Successfully");
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (user == null)
                return NotFound("User Not Found");

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return Ok("User Deleted Successfully");
        }
    }
}
