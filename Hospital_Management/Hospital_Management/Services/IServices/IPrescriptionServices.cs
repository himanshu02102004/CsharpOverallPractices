using Hospital_Management.Model;

namespace Hospital_Management.Services.IServices
{
    public interface IPrescriptionServices
    {

        Task<IEnumerable<Prescription>> GetPrescriptionListAsync();
        Task<Prescription> GetPrescriptionByIdAsync(int  id);

        Task<IEnumerable<Prescription>> GetbyPatientid(int PatientId);// FILTERED LIST

        Task<Prescription> AddAsync(Prescription prescription);

    }
}
