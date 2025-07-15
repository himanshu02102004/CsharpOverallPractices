using Hospital_Management.DTO;
using Hospital_Management.Model;
using Hospital_Management.Services;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {


        private readonly IDoctorService _doctorService;
        public DoctorController( IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var doc = await _doctorService.GetallDoctor();
            return Ok(doc);
        }




        [HttpGet ("id")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var docs= await _doctorService.GetDoctorbyid(id);
            return Ok(docs);
        }



        [HttpPost]

        public async Task <IActionResult> Add(CreateDoctorDto dto)
        {

            var Docs = new Doctor
            {
                Doctor_Name= dto.Name,
                Doctor_Description= dto.Description,
                Doctor_specialization=dto.specialization,
                availability_slot= dto.availabiity,
                IsonLeave=dto.IsonLeave

            };


           await  _doctorService.AddDoctor(Docs);
            return Ok(Docs);
        }



        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Doctor doctor )
        {
            if (id != doctor.Doctor_Id) return BadRequest("Not found doctor");
            var updated = await _doctorService.UpdateDoctor(doctor);
            if (!updated) return NotFound();
            return Ok(updated);


        }




        [HttpDelete("id")]

        public async  Task<IActionResult> delete(int id)
        {
            var delete= await _doctorService.DeleteDoctor(id);
            if(!delete) return NotFound();
            return NoContent();

        }

        [HttpPatch]

        public async Task<IActionResult> Partialupdate(int id, bool IsonLeave)
        {

            var partial= await _doctorService.Markonleave(id, IsonLeave);
            if (!partial) return NotFound();
            return NotFound();
           
        }
       



    }
}
