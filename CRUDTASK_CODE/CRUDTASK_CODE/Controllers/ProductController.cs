using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CRUDTASK_CODE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase


    {
        private readonly ApiContext productContext;

        public ProductController(ApiContext productContext)
        {

            this.productContext = productContext;
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

            await productContext.Products.AddAsync(product);
            await productContext.SaveChangesAsync();

            return Ok("Product Added Successfully");
        }


        [HttpGet("getproduct")]

        public async Task<ActionResult<List<Product>>> getprod()
        {
            var productss = await productContext.Products.ToListAsync();
            return Ok(productss);
        }


        [HttpGet("GetProductByID/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productContext.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }




        [HttpGet("GetProductsByFilter")]
        public async Task<ActionResult<List<Product>>> GetProductsByFilter(int page = 1, int size = 10)
        {
            if (page <= 0 || size <= 0)
                return BadRequest("Page and size must be greater than zero.");

           var totalCount = await productContext.Products.CountAsync();

         var pageSizes = (int)Math.Ceiling((double)totalCount / size);

            var products = await productContext.Products
                                               .Skip((page - 1) * size)
                                               .Take(size)
                                               .ToListAsync();

            return Ok(products);
        }


       




        [HttpPut]
        [Route("UpdateTheProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var existingProduct = await productContext.Products.FindAsync(product.PropId);
            if (existingProduct == null)
                return NotFound("Product not found");

            existingProduct.PropName = product.PropName;
            existingProduct.PropPrice = product.PropPrice;
            existingProduct.CategoryId = product.CategoryId;

            await productContext.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }



        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productContext.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            productContext.Products.Remove(product);
            await productContext.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }

    }
}
