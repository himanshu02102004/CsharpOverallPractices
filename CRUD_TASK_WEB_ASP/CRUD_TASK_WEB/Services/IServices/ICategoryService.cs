using CRUDTASK_CODE.Models;

namespace CRUD_TASK_WEB.Services.IServices
{
    public interface ICategoryService
    {
        Task<Category> GetCategory(int id);
    }
}
