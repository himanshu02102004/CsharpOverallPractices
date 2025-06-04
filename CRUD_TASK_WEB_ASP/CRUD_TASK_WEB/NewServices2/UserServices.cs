using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.NewServices2.INewServices2;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TASK_WEB.NewServices2
{
    public class UserServices:IUserService
    {
        private readonly ApiContext _UD;
        public UserServices(ApiContext UD)
        {
            _UD = UD;
        }


        public async Task<Users> get()
        {
            var users = await _UD.Users.FindAsync();

         
            return users;
        }

    }
}
