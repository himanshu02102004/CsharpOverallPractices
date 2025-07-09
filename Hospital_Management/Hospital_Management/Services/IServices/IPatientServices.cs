using Hospital_Management.Model;

namespace Hospital_Management.Services.IServices
{
    public interface IPatientServices
    {

        public Task<List<Patient>> GetAllPatient ();
        public  Task<Patient> GetPatientById (int id );
        public Task<Patient> AddPatient(Patient patient);
        public  Task<Patient> UpdatePatient ( Patient patient);
       public Task<Patient> DeletePatient (Patient patient);
       public Task<bool> PartialUpdate(Patient updatepatient);
       public Task<IEnumerable<Patient>> SearchPatient(string query);
    }
}
