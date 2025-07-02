using reviewtask1.DTO;
using reviewtask1.Model;

namespace reviewtask1.Services
{
    public  interface ICustomer
    {


        public Task<Category> AddandupdateCategory(Category cat);
        public Task<Customer> AddandupdateCustomer( Customer cust);
        public Task<Order > AddOrder(Order order );
        public Task<Product> AddProduct(Product prod);
    }

    
}
