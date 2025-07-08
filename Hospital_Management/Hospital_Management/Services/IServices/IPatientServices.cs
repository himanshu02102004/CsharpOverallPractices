using Hospital_Management.Model;

namespace Hospital_Management.Services.IServices
{
    public interface IPatientServices
    {

        Task<Patient> GetAllPatient { get; set; }
        Task<Patient> GetPatientById { get; set; }
        Task<Patient> AddPatient { get; set; }
        Task<Patient> UpdatePatient { get; set; }
        Task<Patient> DeletePatient { get; set; }
    }
}
