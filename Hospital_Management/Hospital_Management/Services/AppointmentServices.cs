using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly Apicontext _apiconext;
        public AppointmentServices( Apicontext apicontext)
        {
            _apiconext = apicontext;
        }





        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
         return    await _apiconext.appointments.Include(e => e.patient)
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
            if (docavail == null|| docavail.IsonLeave) return null;


           var   slots = await GetAvailablesLotsAsync(appointment.Doctor_Id, appointment.Appointment_Date.Date);
            if(slots.Count == 0)

            {
                // No slots left today — check tomorrow
                DateTime nextday =appointment.Appointment_Date.AddDays(1);
               slots = await GetAvailablesLotsAsync(appointment.Doctor_Id, nextday);
                if (slots.Count == 0)
                    return null;  // No slot tomorrow either
                appointment.Appointment_Date = slots.First(); // book first slot tomorrow

            }
            
            else
            {     // if requested time not available, assign first available
               if(!slots.Contains(appointment.Appointment_Date))
                
                    appointment.Appointment_Date = slots.First();
                

            }

            appointment.status = " Scheduled";
               
            _apiconext.appointments.Add(appointment);
            await _apiconext.SaveChangesAsync();
            return appointment;



        }

        public async Task<bool> CancelAppointmeAsync(int id)
        {
           var appoint= await _apiconext.appointments.FindAsync(id);
            if (appoint == null) return false;
            appoint.status = "Cancelled";
            _apiconext.appointments.Update(appoint);
            var result=await _apiconext.SaveChangesAsync();
            return result > 0;
        }



        public async Task<bool> ResheduledAppointment(int id, DateTime newdatetime)
        {
            var appoint = await _apiconext.appointments.FindAsync(id);
            if (appoint == null) return false;
            appoint.Appointment_Date= newdatetime;
            appoint.status = "Reshedule";
            _apiconext.appointments.Update(appoint);

            var result= await _apiconext.SaveChangesAsync();
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
                .Where( a=> a.Doctor_Id== doctor_id && a.Appointment_Date==date.Date)
                .Include(a => a.patient)
                .ToListAsync();

        }

        public Task<IEnumerable<Appointment>> GetAvailablesLotsAsync(int Doctor_id, DateTime date)
        {



        }


    }
}
