using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;

namespace Hospital_Management.Services
{
    


    public class PatientServices : IPatientServices
    {
        private readonly Apicontext apicontext;

        public PatientServices(Apicontext _apicontext)
        {
            apicontext = _apicontext;
        }


        public  async Task<Patient> GetAllPatient {
            var patient= await apicontext
            }
        public Task<Patient> GetPatientById {
           

        }
        public Task<Patient> AddPatient { 
            

        }
        public Task<Patient> UpdatePatient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Task<Patient> DeletePatient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
