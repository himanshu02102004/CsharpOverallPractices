using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TASK_WEB.NewServices.INewServices
{
    public interface IProductServices
    {

        Task<Product> GetProduct(int id);
    }
}
