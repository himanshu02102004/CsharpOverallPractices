using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.NewServices.INewServices;
using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _productContext;
        private readonly IProductServices _productServices;

        public ProductController(ApiContext productContext, IProductServices productServices )
        {
            _productContext = productContext;
            _productServices = productServices;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            var product = new Product
            {
                PropName = productDto.PropName,
                PropPrice = productDto.PropPrice,
                CategoryId = productDto.CategoryId
            };

            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();

            return Ok("Product Added Successfully");
        }



        [HttpGet("getproduct")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productContext.Products.Select(X => new ProductDTO
            {
                PropName = X.PropName,
                PropPrice = X.PropPrice,
                CategoryId = X.CategoryId
            }).
                ToListAsync();
            return Ok(products);
        }





        [HttpGet("GetProductByID/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }



        [HttpGet("GetProductsByFilter")]
        public async Task<ActionResult<List<Product>>> GetProductsByFilter(int page = 1, int size = 10)
        {
            if (page <= 0 || size <= 0)
                return BadRequest("Page and size must be greater than zero.");

            var totalCount = await _productContext.Products.CountAsync();
            var pageSizes = (int)Math.Ceiling((double)totalCount / size);

            var products = await _productContext.Products
                                                .Skip((page - 1) * size)
                                                .Take(size)
                                                .ToListAsync();

            return Ok(products);
        }

        [HttpPut("UpdateTheProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var existingProduct = await _productContext.Products.FindAsync(product.PropId);
            if (existingProduct == null)
                return NotFound("Product not found");

            existingProduct.PropName = product.PropName;
            existingProduct.PropPrice = product.PropPrice;
            existingProduct.CategoryId = product.CategoryId;

            await _productContext.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}

