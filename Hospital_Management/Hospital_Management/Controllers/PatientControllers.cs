
using Hospital_Management.Database;
using Hospital_Management.DTO;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Hospital_Management.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientControllers: ControllerBase
    {
        private readonly Apicontext _context;

        private readonly IPatientServices _patientServices;

        public PatientControllers( IPatientServices patientServices, Apicontext apicontext)
        {
         _patientServices = patientServices;
            _context = apicontext;
        }

        [HttpGet]

        public async Task<IActionResult> Patientall()
        {
            var info = await _patientServices.GetAllPatient();
            if (info == null) return BadRequest("none of patient ");
            return Ok(info);
        }


        [HttpGet("id")]

        public async Task<IActionResult> Patientbyid(int id)
        {
            var infos= await _patientServices.GetPatientById(id);
            if (infos == null) return NotFound();
            return Ok(infos);
        }


        [HttpPost("createpatient")]

        public async Task<IActionResult> AddPatient(CreatePatientDto dto)
        {
            var cus = new Patient
            { 
               Patient_name= dto.Patient_name,
               patient_phoneNo=dto.Patient_Phone,
               Patient_description=dto.Patient_description,
                   Email=dto.Patient_Email

            };

            await _patientServices.AddPatient(cus); 
            return Ok(cus);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Patientdelete(int id)
        {
            var delete = await _patientServices.DeletePatient(id);
            if (delete == null) return NotFound();
            
            return Ok(new { message ="patient delete succesfully"});

        }

        [HttpPut("Updatebyid")]

        public async Task<IActionResult> PatientUpdate(int id, Patient patient)
        {

            if( id != patient.Patient_id) return BadRequest( "patient ID is mismatched ");

            var existing= await _context.Patients.FindAsync(id);
            if (existing == null) return NotFound();

            // update properties

            existing.Patient_name = patient.Patient_name;
            existing.Patient_description=patient.Patient_description;
            existing.patient_phoneNo=patient.patient_phoneNo;
            existing.Email = patient.Email;

            await _context.SaveChangesAsync();
            return Ok("update succesfully");



           
        }


        [HttpPatch("Partialupdate")]

         public async Task<IActionResult> partialupdate(int id, Patient patient)
        {
            if (id != patient.Patient_id) return BadRequest("ID GET MISSMATCHED");

            var partialupdate = await _patientServices.PartialUpdate(patient);
            if(!partialupdate) return NotFound();
            return NoContent();

           

        }

        [HttpGet("Search")]

        public async Task<IActionResult> SearchPatient(string query)
        {


            var patient= await _patientServices.SearchPatient(query);
         if (patient == null || !patient.Any()) return BadRequest("No matching patient found");

         return Ok(patient);


        }





    }
}
