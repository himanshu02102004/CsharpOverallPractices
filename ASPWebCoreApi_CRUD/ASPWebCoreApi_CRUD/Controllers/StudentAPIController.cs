using ASPWebCoreApi_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ASPWebCoreApi_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDbContext context;

        public StudentAPIController(MyDbContext context)

        {
            this.context = context;
        }


        [HttpGet]

        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);   // LIST MEIN CONVERT KARKE RETURN KARWAYEGA
        }




        [HttpGet("{id}")]

        public async Task<ActionResult<Student>> GetstudentbyID(int id)
        {
            var student = await context.Students.FindAsync(id);  // check karega kya ye id student mein hai ki nhi 
        
         if(student == null)
            {
                return NotFound();
            }


            return student;
        
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreatestudentbyID(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Student>>  CreatestudentbyID(int id,Student std)   /// updated data student mein save hoga ,id int id mein
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Updatestudent(int id, Student std) 
        { 
          if(id != std.Id)
            {
                return BadRequest();
            }

            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }


        [HttpDelete("id") ]

        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }

            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }




    }
}
