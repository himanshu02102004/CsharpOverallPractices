
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reviewtask1.DTO;
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

        public async Task<Category> AddandupdateCategory( Category cat)
        {

           var existing=await _context.categories
                                        .Include(c=> c.Products)
                                        .FirstOrDefaultAsync(c => c.CategoryID == cat.CategoryID);
           

            if(existing == null)
            {
                _context.categories.Add(cat);
            }
            else
            {
                existing.CategoryID = cat.CategoryID;
                existing.Products = cat.Products;
            }
            await _context.SaveChangesAsync();
            return cat;


        }

  //      [HttpPost()]
        public async Task<Customer> AddandupdateCustomer(Customer cus)
        {
            

            var getnew = await _context.customers.FindAsync(cus.CustomerID);

            if(getnew == null)
            {
                await _context.customers.AddAsync(cus);
            }
            else
            {
                getnew.CustomerID = cus.CustomerID;
                getnew.CustomerName = cus.CustomerName;
                getnew.CustomerEmail=cus.CustomerEmail;
              
            }
            await _context.SaveChangesAsync();
            return cus;

        }

        public async Task<Order> AddOrder(Order  order)
        {
            var exis = await _context.orders.FirstOrDefaultAsync(o => o.CustomerID== order.CustomerID);

            if (exis== null)
            {
                _context.orders.Add(order);
            }
            else
            {
                {
                    exis.OrderID = order.OrderID;
                    exis.OrderDate= order.OrderDate;
                    exis.Products=order.Products;
                }
            }

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Product> AddProduct(  Product product)
        {
             var exis=await _context.products.FirstOrDefaultAsync(P=> P.ProductID == product.ProductID);
     
        
          if(exis == null)
            {
                await _context.products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            else
            {
                exis.ProductID = product.ProductID;
                exis.ProductName = product.ProductName;
                exis.ProductPrice=product.ProductPrice;
                exis.categoryID = product.categoryID;
                await _context.SaveChangesAsync();
                return exis;

            }


        }
    }
}
