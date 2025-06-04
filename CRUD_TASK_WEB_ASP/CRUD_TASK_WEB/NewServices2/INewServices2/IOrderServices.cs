using CRUDTASK_CODE.Models;

namespace CRUD_TASK_WEB.NewServices2.INewServices2
{
    public interface IOrderServices
    {

        Task<Order> GetOrders();
    }
}
