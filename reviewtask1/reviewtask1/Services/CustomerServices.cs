
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using reviewtask1.Model;

namespace reviewtask1.Services
{
    public class CustomerServices : ICustomer
    {


        private readonly ApiContext _context;

        public CustomerServices(ApiContext context)
        {
            _context = context;
        }

        public async Task<Category> AddandupdateCategory(Category cat)
        {

            var sav =await  _context.categories.FindAsync(cat.CategoryID);
            var prods = _context.categories.Include(c => c.Products);
            if (sav == null)
            {
                _context.categories.Add(cat);
            }
            else
            {
                sav.CategoryID = cat.CategoryID;

            }

        }

        public Task<Customer> AddandupdateCustomer(Customer customer)
        {
            
        }

        public Task<Order> AddCategory(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
