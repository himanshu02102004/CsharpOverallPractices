using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserContrext usercontrext;

        public UsersController(UserContrext userContrext)
        {

            this.usercontrext = userContrext;
        }

        [HttpGet]
        [Route("GetUsers")]

        public List<Users> GetUsers()
        {
            return usercontrext.Users.ToList();
        }


        [HttpGet]
        [Route("GetUser")]

        public Users GetUser(int ID)
        {
            return usercontrext.Users.Where(x => x.ID == ID).FirstOrDefault();
        }




        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users users)
        {
            string response = string.Empty;
            usercontrext.Users.Add(users);
            usercontrext.SaveChanges();
            return "User Added Successfully";
        }

        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(Users users)
        {

            usercontrext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            usercontrext.SaveChanges();

            return " User Updated Successfully";
        }

        [HttpDelete]
        [Route("DeleteUser")]

        public string DeleteUser(int id)
        {
            Users users= usercontrext.Users.Where(x => x.ID == id).FirstOrDefault();

            if (users == null)
            {
                return "User Not Found";
            }
            else
            {

                usercontrext.Users.Remove(users);
                usercontrext.SaveChanges();
                return "User Deleted Successfully";
            }
        }
    }
}
