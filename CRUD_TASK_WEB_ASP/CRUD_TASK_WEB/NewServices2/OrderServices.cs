using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.NewServices2.INewServices2;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TASK_WEB.NewServices2
{
    public class OrderServices: IOrderServices
    {
        private readonly ApiContext _OD;

        public OrderServices( ApiContext OD)
        {
            _OD = OD;
        }

        public async Task<Order> GetOrders()
        {
            var orders = await _OD.Orders.FindAsync();
               

            return orders;
        }



    }
}
