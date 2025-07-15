using Hospital_Management.DTO;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public async  Task<IActionResult> GETALLDEPARTMENT()
        {
            var department = await _departmentServices.GetAlldepartment();
            if (department == null) return BadRequest("Department is not available");
            return Ok(department);
        }


        [HttpGet("id")]
        public async Task<IActionResult> Getbyidepartmentid(int id)
        {
            var dept= await _departmentServices.GetDepartmentbyID(id);
            if (dept == null) return NotFound();
            return Ok(dept);
        }



        [HttpPost("create department")]
         public async Task<IActionResult> create(CreateDepartment depart )      
        {
            var creat = await _departmentServices.CreateDepartment(depart);
            return CreatedAtAction(nameof(Getbyidepartmentid),new {id= creat.Department_Id},create);
        }


        [HttpPut("id")]
        public async Task<IActionResult> update(int id, Department depart)
        {
            if (id != depart.Department_Id) return BadRequest(" id is mismatached");
            var update = await _departmentServices.UpdateDepartment(depart);
            if (!update) return NotFound();
            return NoContent();
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _departmentServices.DeleteDepartment(id);
            if(!delete) return NotFound();  
            return Ok(delete);

        }




    }
}
