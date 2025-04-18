using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }






        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO productDto)
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








        [HttpGet("GetProduct")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productContext.Products.ToListAsync();
            return Ok(products);
        }




        [HttpGet("GetProductID/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(x => x.PropId == id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

       

        [HttpPut("UpdatetheProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(x => x.PropId == id);

            if (product == null)
                return NotFound("Product not found");

            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}
