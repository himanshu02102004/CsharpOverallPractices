using reviewtask1.Model;

namespace reviewtask1.Services
{
      interface ICustomer
    {


        public Task<Category> AddandupdateCategory(Category cat);
        public Task<Customer> AddandupdateCustomer( Customer cust);
        public Task<Order > AddCategory(Order ord);
        public Task<Product> AddProduct(Product prod);
    }

    
}
