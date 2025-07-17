using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{

    [ApiController]
    [Route("api/medical-record")]
    public class MedicalRecordController : ControllerBase
    {


        private readonly IMedicalRecordServices medicalrecordservices;
        public MedicalRecordController( IMedicalRecordServices _medicalrecordservices)
        {

            medicalrecordservices = _medicalrecordservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var record = await medicalrecordservices.GetPrescriptionListAsync();
            return Ok(record);


        }


        [HttpGet("id")]
        public async Task<IActionResult> GetbyPrescriptionid(int id)
        {
            var record= await medicalrecordservices.GetPrescriptionByIdAsync(id);
            if (record == null) {
                return BadRequest("Prescription is not available");
            }

            return Ok(record);
        }

        [HttpGet("patient-id")]
        public async Task<IActionResult> GetbyPatientid( int patientid)
        {

            var pat = await medicalrecordservices.GetbyPatientid(patientid);
            return Ok(pat);


        }
        [HttpPost("add")]
        public async Task<IActionResult> Add( MedicalRecord prescription)
        {
          var aded= await medicalrecordservices.AddAsync(prescription);
            return CreatedAtAction(nameof(GetbyPrescriptionid), new { id = aded.ID}, aded);
          
        }
    }
}