using Modularization_code.Model;

namespace Modularization_code.Services.Interfaces
{
    public interface  IProductServices
    {
        Task<IEnumerable<Model.Product>> GetAllProductSync();

        Task<Product> GetProductByIdSync(int id);
        Task<Product> AddProductSync(Product product);
        Task<Product> CreateProductAsync(Product product);  
        Task<Product> UpdateProductSync(Product product);
        Task<bool> DeleteProductSync(int id);



    }
}
