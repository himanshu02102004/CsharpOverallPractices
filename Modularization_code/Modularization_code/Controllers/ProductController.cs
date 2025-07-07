using Microsoft.AspNetCore.Mvc;
using Modularization_code.Model;
using Modularization_code.Services.Interfaces;

namespace Modularization_code.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices productServices)
        {
            _services = productServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GETAll() => Ok(await _services.GetAllProductSync());


        [HttpGet("{ID}")]

        public async Task<IActionResult> Getbyid(int ID)
        {
            var product=await _services.GetProductByIdSync(ID);
            if(product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var created=await _services.CreateProductAsync(product);
            return CreatedAtAction(nameof(Getbyid), new { id = created.PropId }, created);

        }



        [HttpPut("id")]
        public async Task<IActionResult> Update(int id ,Product product)
        {
            if(id != product.PropId)
            {
              
                return BadRequest("ID Mismatch");
            }

            var updated = await _services.UpdateProductSync(product);
            return Ok(updated);
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var success=await _services.DeleteProductSync(id);
            if(!success) return false;
            return true;
        }
    }
}
