using CRUDTASK_CODE.Models;

namespace CRUD_TASK_WEB.NewServices2.INewServices2
{
    public interface IUserService
    {

        Task<Users> get();
    }
}
