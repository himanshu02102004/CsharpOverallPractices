using Modularization_code.Model;

namespace Modularization_code.Repositories.Interfaces
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllSync();
        Task<Product> GetByIdSync(int id);
        Task<Product> AddSync(Product product);
        Task<Product> UpdateSync(Product product);
        Task<bool> DeleteSync(int id);

    }
}
