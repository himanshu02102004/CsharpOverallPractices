using Microsoft.EntityFrameworkCore;
using Modularization_code.Data;
using Modularization_code.Model;
using Modularization_code.Repositories.Interfaces;
using Modularization_code.Services.Interfaces;

namespace Modularization_code.Repositories
{
    public class ProductRepository :IProductRepository
    {



        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetAllSync() => await _context.Products.ToListAsync();


        public async Task<Product> GetByIdSync(int id) => await _context.Products.FindAsync(id);


        public async Task<Product> AddSync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> UpdateSync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<bool> DeleteSync(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if(prod== null)
            {
                return false;
            }
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return true;
        }



      
    }
    }

