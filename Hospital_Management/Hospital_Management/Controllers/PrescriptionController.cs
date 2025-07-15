using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {


        private readonly IPrescriptionServices prescriptionServices;
        public PrescriptionController( IPrescriptionServices _prescriptionServices )
        {
           
          prescriptionServices = _prescriptionServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var record = await prescriptionServices.GetPrescriptionListAsync();
            return Ok(record);


        }


        [HttpGet("id")]
        public async Task<IActionResult> GetbyPrescriptionid(int id)
        {
            var record= await prescriptionServices.GetPrescriptionByIdAsync(id);
            if (record == null) {
                return BadRequest("Prescription is not available");
            }

            return Ok(record);
        }

        [HttpGet("Getbypatientid")]
        public async Task<IActionResult> GetbyPatientid( int patientid)
        {

            var pat = await prescriptionServices.GetbyPatientid(patientid);
            return Ok(pat);


        }
        [HttpPost("add")]
        public async Task<IActionResult> Add( Prescription prescription)
        {
          var aded= await   prescriptionServices.AddAsync(prescription);
            return CreatedAtAction(nameof(GetbyPrescriptionid), new { id = aded.Id}, aded);
          
        }
    }
}