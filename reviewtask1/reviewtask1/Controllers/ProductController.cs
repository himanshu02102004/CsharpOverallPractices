using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reviewtask1.Model;

namespace reviewtask1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {


        private readonly ApiContext _apiContext;
        public ProductController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _apiContext.products.ToListAsync();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Getproductbyid(int id)
        {
            var product = await _apiContext.products.Include(p => p.category)
                .FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null) return NotFound();
            return Ok(product);



        }


        [HttpPost]
      //  [HttpGet]
        public async Task<IActionResult> createproduct( [FromQuery] Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.ProductName))
            {
                return BadRequest("Invalid product data.");
            }
            _apiContext.products.Add(product);
            await _apiContext.SaveChangesAsync();
            return Ok(" Product created successfully");

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> updateProduct(int id, Product product)
        {
            if (id != product.ProductID) return BadRequest("product ID mismatch.");

            _apiContext.Entry(product).State = EntityState.Modified;
            await _apiContext.SaveChangesAsync();
            return Ok("Product updated successfully.");


        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteproduct(int id)
        {
            var existingProduct = await _apiContext.products.FindAsync(id);
            if (existingProduct == null) return NotFound();

            _apiContext.products.Remove(existingProduct);
            await _apiContext.SaveChangesAsync();
            return Ok("Product deleted successfully.");


        }



    }
}
