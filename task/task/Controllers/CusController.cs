
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task.Model;


namespace task.Controllers
{
    [ApiController]
    [Route("api / controller")]


    public class CusController : ControllerBase


    {


        private readonly Apicontext apicontext1;
        public CusController(Apicontext apicontext)
        {
            this.apicontext1 = apicontext;
            
        }

        [HttpGet("getcus")]
        public async Task<ActionResult<List<Customer>>> get(string n)
        {
            var nam = await apicontext1.customers.FirstOrDefaultAsync(x => x.name ==n);
            if (n == null)
            {
                return NotFound("not found");
            }

            return Ok(nam);
        }

        [HttpPost("addcus")]

        public async Task<ActionResult<List<Customer>>> add()
        {
            var add=await apicontext1.customers.AddAsync();

            apicontext1.SaveChangesAsync();

            return Ok(add);

        }


    }
}
