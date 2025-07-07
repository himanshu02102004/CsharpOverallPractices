using Modularization_code.Model;
using Modularization_code.Repositories.Interfaces;
using Modularization_code.Services.Interfaces;

namespace Modularization_code.Services
{
    public class ProductServices : IProductServices
    {


        private readonly IProductRepository _productRepository;
        public ProductServices (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

     public async    Task<IEnumerable<Model.Product>> GetAllProductSync() => await _productRepository.GetAllSync();




   public async Task<Product> GetProductByIdSync(int id) => await _productRepository.GetByIdSync(id);

      public async Task<Product > AddProductSync(Product product) => await _productRepository.AddSync(product);

        public async Task<Product> CreateProductAsync(Product product) => await _productRepository.AddSync(product);
     public async Task<Product> UpdateProductSync(Product product) => await _productRepository.UpdateSync(product);





    public async Task<bool> DeleteProductSync(int id) => await _productRepository.DeleteSync(id);


    }
}
