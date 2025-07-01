using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: Controller
    {
     

        private readonly Apicontext _context;

        public CustomerController(Apicontext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> create(Product product)
        {
            if{
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                _context.products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(create), new { id = product.Propid }, product);
            }
            else
            {

            }


        }



    }
}
