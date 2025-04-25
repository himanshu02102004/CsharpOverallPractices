using CRUD_TASK_WEB.DTOs;
using CRUD_TASK_WEB.Models;
using CRUDTASK_CODE.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly ApiContext usercontrext;



        public UsersController(ApiContext userContrext)
        {

            this.usercontrext = userContrext;

        }

        [HttpGet]
        [Route("GetUsersfrom filter")]

        public async Task<ActionResult<List<Users>>> GetUsers(int page = 1, int size = 4)
        {
            var count = await usercontrext.Users.CountAsync();
            var pageSizes = (int)Math.Ceiling((double)count / size);

            var data = await usercontrext.Users
                                       .Skip((page - 1) * size)
                                       .Take(size)
                                       .ToListAsync();

            return Ok(data);
        }

        [HttpGet("getuser")]

        public async Task<ActionResult<List<Users>>> get()
        {
            var users = await usercontrext.Users.ToListAsync();
           
            if (users == null)
            {
                return NotFound("user not present");
            }
            return Ok(users);
        }




        [HttpGet("GetUserByID")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await usercontrext.Users.FirstOrDefaultAsync(x => x.ID == id && x.IsDeleted ==true);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }






        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<string>> AddUser(UserDTO user)
        {

            var hashed = BCrypt.Net.BCrypt.HashPassword(user.password);
            var data = new Users
            {
                Name=user.Name,
                emailaddress=user.emailaddress,
                ContactNo=user.ContactNo,
                password=hashed

            };
            usercontrext.Users.Add(data);
            await usercontrext.SaveChangesAsync();
            return Ok("User Added Successfully");

           




        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<string>> UpdateUser(Users users)
        {
            usercontrext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await usercontrext.SaveChangesAsync();
            return Ok("User Updated Successfully");
        }

        //[HttpDelete]
        //[Route("DeleteUser")]
        //public async Task<ActionResult<string>> DeleteUser(int id)
        //{
        //    var users = await usercontrext.Users.FirstOrDefaultAsync(x => x.ID == id);

        //    if (users == null)
        //    {
        //        return NotFound("User Not Found");
        //    }

        //    usercontrext.Users.Remove(users);
        //    await usercontrext.SaveChangesAsync();
        //    return Ok("User Deleted Successfully");
        //}


        //[HttpDelete("{id}")]
        //[Route("DeleteUser")]
        //public async Task<ActionResult<string>> DeleteUsers(int id)
        //{
        //    var users = await usercontrext.Users.FirstOrDefaultAsync(x => x.ID == id);

        //    if (users == null)
        //    {
        //        return NotFound("User Not Found");
        //    }

        //    users.IsDeleted = true;
        //    await usercontrext.SaveChangesAsync();
        //    return Ok("User Deleted Successfully");
        //}

        [HttpDelete("DeleteUserSoft/{id}")]
        public async Task<ActionResult<string>> DeleteUsers(int id)
        {
            var user = await usercontrext.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (user == null)
                return NotFound("User Not Found");

            user.IsDeleted = true;
            await usercontrext.SaveChangesAsync();

            return Ok("User Soft Deleted Successfully");
        }
    }
}



