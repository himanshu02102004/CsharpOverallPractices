using exercisescrud.DTO;
using exercisescrud.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks.Dataflow;


namespace exercisescrud.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly ApiContext usercontext;
        public UserController( ApiContext userContrext )
        {

            this.usercontext = userContrext;
        }

        [HttpGet("getuser")]

        public async Task<ActionResult<List<User>>> get()
        {
            var users = await usercontext.user.ToListAsync();

            if (users == null)
            {
                return NotFound("user is not available");
            }

            return Ok(users);
        }






        [HttpDelete("get user by filter")]

        public async Task<ActionResult<List<User>>> getuserfilter(int page=1,int size=3)
        {

            var counts = await usercontext.user.CountAsync();
            var pagesize = (int)Math.Ceiling((double)counts / size);
            var data = await usercontext.user
                                      .Skip((page - 1) * size)
                                      .Take(size)
                                      .ToListAsync();
            return Ok(data);


            

        }





        [HttpGet("get user by id")]
        public async Task<ActionResult<User>> getuser(int ID)
        {
            var user = await usercontext.user.FirstOrDefaultAsync(x => x.Id == ID);


            if (user == null)
            {
                return NotFound("user not available");
            }

            return Ok(user);
        }

        [HttpPost("Adduser")]

        public async Task<ActionResult<string>> adduser(UserDto userDto)
        {


            var hash = BCrypt.Net.BCrypt.HashPassword(userDto.password);
            var data = new User
            {
                name = userDto.name,
                username = userDto.username,
                password = hash
            };

            usercontext.Add(data);
            await usercontext.SaveChangesAsync();
            return Ok("user added succesfully");

        }



        [HttpPut("update user")]

        public async Task<ActionResult<string>> update(User user)
        {

            usercontext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await usercontext.SaveChangesAsync();
            return Ok("user update successfully");



        }

        [HttpDelete("delete the user")]

        public async Task<ActionResult<string>> delete(int id)
        {
            var user = await usercontext.user.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound("user not found");
            }


            usercontext.user.Remove(user);

            await usercontext.SaveChangesAsync();
            return Ok("user delete succesfuuly");


        }





    }
}
