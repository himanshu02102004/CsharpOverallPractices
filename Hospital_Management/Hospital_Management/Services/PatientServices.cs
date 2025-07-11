  using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    


    public class PatientServices : IPatientServices
    {
        private readonly Apicontext apicontext;

        public PatientServices(Apicontext _apicontext)
        {
            apicontext = _apicontext;
        }


        public  async Task<List<Patient>> GetAllPatient() {
            var patient= await apicontext.Patients.ToListAsync();
            if(patient == null)
            {
                return null;
            }
            return patient;

            }
        public async Task<Patient> GetPatientById(int id) {
            return await apicontext.Patients.FindAsync(id);

        }
        public async Task<Patient> AddPatient(Patient patient) {

            apicontext.Patients.Add(patient);
            await apicontext.SaveChangesAsync();
            return patient;
            

        }
        public async Task<Patient> UpdatePatient (Patient patient){
            var update = await apicontext.Patients.FindAsync(patient.Patient_id);
            if(update == null)
            {
                return null;


            }


            patient.Patient_name = update.Patient_name;
            patient.Patient_description=update.Patient_description;
            patient.patient_phoneNo = update.patient_phoneNo;
           
            await apicontext.SaveChangesAsync();
            return patient;
        }


        public async Task<Patient> DeletePatient(int id) { 
           var pat= await apicontext.Patients.FindAsync(id);
            if(pat == null)
            {
                return null;
            }

            apicontext.Patients.Remove(pat);
            await apicontext.SaveChangesAsync();
            return pat;


        
        }




        public async Task<IEnumerable<Patient>> SearchPatient(string query) {

            return await apicontext.Patients
                .Where(p => p.Patient_name.ToLower().Contains(query.ToLower())
                || p.patient_phoneNo.Contains(query))
             
            .ToListAsync();
            
        
        }
        public async Task<bool> PartialUpdate(Patient updatepatient) {
            var existing = await apicontext.Patients.FindAsync(updatepatient.Patient_id);
            if(existing== null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(updatepatient.Patient_name))
            {
                existing.Patient_name = updatepatient.Patient_name;
            }
            if (!string.IsNullOrEmpty(updatepatient.Patient_description))
            {
                existing.Patient_description= updatepatient.Patient_description;
            }
            if (!string.IsNullOrEmpty(updatepatient.patient_phoneNo))
            {
                existing.patient_phoneNo = updatepatient.patient_phoneNo;
            }
            await apicontext.SaveChangesAsync();
            return true;

        
        }

    }
}
