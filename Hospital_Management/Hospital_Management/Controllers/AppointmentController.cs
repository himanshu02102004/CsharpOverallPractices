using Hospital_Management.Database;
using Hospital_Management.DTO;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class AppointmentController: ControllerBase
    {
        private readonly IAppointmentServices _appointmentServices;

        public AppointmentController( IAppointmentServices appointmentServices)
        {
             _appointmentServices = appointmentServices;
        }


        [HttpPost]

        public async Task<IActionResult> bookappointment(BookAppointmentDto dto)
        {
            if (dto == null) return BadRequest(" Invalid appointment data");
            var appoint = new Appointment
            {
                Doctor_Id=dto.doctor_ID,
              Patient_id =dto.Patient_ID,
               Appointment_Date=dto.dateTime,
              status="Scheduled"
            };
            var bookappoint= await _appointmentServices.BookAppointment(appoint);
            if (bookappoint == null) return BadRequest("SLOT NOT AVAILABLE OR DOCTOR UNAVAILABLE");
            return Ok(bookappoint);
        }

        [HttpPatch("{id}/ cancel")]

        public async Task<IActionResult> cancelappointment(int id)
        {
            var result= await _appointmentServices.CancelAppointmeAsync(id);
            if (!result) return BadRequest("not available appointment ");
            return Ok(result);
        }

        [HttpPatch("{id}/resheduled")]
        public async Task<IActionResult> resheduled(int id, DateTime dateTime)
        {
           

            var appoint= await _appointmentServices.ResheduledAppointment(id, dateTime);

        }



    }
}
