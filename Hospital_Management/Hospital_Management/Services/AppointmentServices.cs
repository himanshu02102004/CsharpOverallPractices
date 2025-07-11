using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly Apicontext _apiconext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailServices _emailservices;
        public AppointmentServices(Apicontext apicontext,IHttpContextAccessor httpContextAccessor, IEmailServices emailServices)
        {
            _apiconext = apicontext;
            _httpContextAccessor = httpContextAccessor;
            _emailservices = emailServices;
        }





        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _apiconext.appointments.Include(e => e.patient)
                                            .Include(e => e.Doctor)
                                            .ThenInclude(e => e.Department)
                                            .ToListAsync();


        }



        public async Task<Appointment> GetAppointmentbyID(int id)
        {
            return await _apiconext.appointments.Include(e => e.patient)
                                                .Include(e => e.Doctor)
                                                .ThenInclude(e => e.Department)
                                                .FirstOrDefaultAsync(e => id == id);


        }
        public async Task<Appointment> BookAppointment(Appointment appointment)
        {

            /// doctor availabe check
            var docavail = await _apiconext.doctors.FindAsync(appointment.Doctor_Id);
            if (docavail == null || docavail.IsonLeave) return null;


            var slots = await GetAvailablesLotsAsync(appointment.Doctor_Id, appointment.Appointment_Date.Date);
            if (slots.Count == 0)

            {
                // No slots left today — check tomorrow
                DateTime nextday = appointment.Appointment_Date.AddDays(1);
                slots = await GetAvailablesLotsAsync(appointment.Doctor_Id, nextday);
                if (slots.Count == 0)
                    return null;  // No slot tomorrow either
                appointment.Appointment_Date = slots.First(); // book first slot tomorrow

            }

            else
            {     // if requested time not available, assign first available
                if (!slots.Contains(appointment.Appointment_Date))

                    appointment.Appointment_Date = slots.First();


            }

            appointment.status = " Scheduled";

            _apiconext.appointments.Add(appointment);
            await _apiconext.SaveChangesAsync();





            var currentUser = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "Unknown User";

            var currentRole = _httpContextAccessor.HttpContext?.User.Claims
                            .FirstOrDefault(c => c.Type == "Role")?.Value ?? "Unknown Role";


            // Log action
            await LogActionAsync("Book Appointment ", currentRole, $" Booked  appointment for patient " +
                $" {appointment.Patient_id} with doctor {appointment.Doctor_Id} at {appointment.Appointment_Date} by {currentUser}");


            var patients = await _apiconext.Patients.FindAsync(appointment.Patient_id);
            var doctor1 = await _apiconext.doctors.FindAsync(appointment.Doctor_Id);






            // prepare email data
            string patientemail = patients.Email;
            string doctorname = doctor1.Doctor_Name;


            // SEND EMAIL CONFIRMATON 
            await _emailservices.SendEmailAsync(patientemail, 
                "Appointment Confirmation " ,
                $"your appoitment is confirmed with doctor {doctor1.Doctor_Name} at {appointment.Appointment_Date} ");




            return appointment;



        }

        public async Task<bool> CancelAppointmeAsync(int id)
        {
            var appoint = await _apiconext.appointments.FindAsync(id);
            if (appoint == null) return false;
            appoint.status = "Cancelled";
            _apiconext.appointments.Update(appoint);
            var result = await _apiconext.SaveChangesAsync();
            return result > 0;
        }



        public async Task<bool> ResheduledAppointment(int id, DateTime newdatetime)
        {
            var appoint = await _apiconext.appointments.FindAsync(id);
            if (appoint == null) return false;
            appoint.Appointment_Date = newdatetime;
            appoint.status = "Reshedule";
            _apiconext.appointments.Update(appoint);

            var result = await _apiconext.SaveChangesAsync();
            return result > 0;
        }





        public async Task<IEnumerable<Appointment>> GetAppointmentbyDoctorandDate(int doctor_id, DateTime date)
        {
            return await _apiconext.appointments
                  .Where(a => a.Doctor_Id == doctor_id && a.Appointment_Date == date.Date && a.status == "Scheduled")
                  .Include(a => a.patient)
                  .ToListAsync();

        }
        public async Task<IEnumerable<Appointment>> GetDoctorSchedule(int doctor_id, DateTime date)
        {
            // Similar to GetAppointmentsByDoctorAndDateAsync, but can include all statuses or more filters
            return await _apiconext.appointments
                .Where(a => a.Doctor_Id == doctor_id && a.Appointment_Date == date.Date)
                .Include(a => a.patient)
                .ToListAsync();

        }

        public async Task<List<DateTime>> GetAvailablesLotsAsync(int doctor_id, DateTime date)
        {
            var doctor = await _apiconext.doctors.FindAsync(doctor_id);
            if (doctor == null || doctor.IsonLeave)
                return new List<DateTime>();

            // dEFINE WORKING HOUR
            DateTime starttime = date.Date.AddHours(8);
            DateTime endtime = date.Date.AddHours(18);
            DateTime breakstart = date.Date.AddHours(13);
            DateTime breakend = date.Date.AddHours(14);

            List<DateTime> slots = new();
            while (starttime < endtime)
            {
                // skip break

                if (starttime >= breakstart && starttime < breakend)
                {
                    starttime = breakend;
                    continue;
                }
                // check  if slot already book

                bool isbooked = await _apiconext.appointments
                    .AnyAsync(p => p.Doctor_Id == doctor_id && p.Appointment_Date == starttime && p.status == "Scheduled");
                if (!isbooked)
                {
                    slots.Add(starttime);
                }
                starttime = starttime.AddMinutes(30);


            }

            return slots;


        }

        private async Task LogActionAsync(string action , string performedby,string details)
        {
            var log = new Auditlog
            {

                Action = action,
                Performedby = performedby,
                PerformedAt = DateTime.Now,
                detail = details

            };
            _apiconext.Auditlogs.Add(log);

            await _apiconext.SaveChangesAsync();
            var currentuser = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "Unknown User";
            var currentRole = _httpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "role")?.Value ?? " Unknown Role";


        }
    }
}