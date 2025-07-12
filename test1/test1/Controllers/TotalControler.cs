

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test1.Model;

namespace test1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TotalControler: Controller
    {

        private readonly ApiContext _context;
        public TotalControler( ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> getall()
        {
            var info=  await _context.products.ToListAsync();
            if (info == null)  return NotFound();
                return Ok(info);

        }



        [HttpPost("add")]
        public async Task<IActionResult> add(Product product)
        {
            var exist = await _context.products.FindAsync(product.Prod_Id);

            if(exist== null)
            {
                _context.products.Add(product);

                return Ok("Successfully ");
            }else
            exist.Prod_Description=product.Prod_Description;
            await _context.SaveChangesAsync();
            return Ok(exist);


        }
        [HttpPost("adddoctor")]
        public async Task<IActionResult> adddoctor(Doctor doctor)
        {
            var exost = await _context.Doctors.FindAsync(doctor.Doc_Id);
            if(exost== null)
            {
                _context.Doctors.Add(doctor);
            }
            else
            {
                exost.Doc_Id=doctor.Doc_Id;
                exost.Doc_Name=doctor.Doc_Name; 
            }
           await _context.SaveChangesAsync();
            return Ok(exost);
        }

    }
}
