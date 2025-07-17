using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class MedicalrecordServices : IMedicalRecordServices
    {

        private readonly Apicontext _apicontext;

        public MedicalrecordServices( Apicontext apicontext)
        {
         _apicontext = apicontext;   
        }




        public async Task<IEnumerable<MedicalRecord>> GetPrescriptionListAsync()
        {
            return await _apicontext.prescriptions
                      .Include(r => r.Patient)
                      .Include(r => r.doctor)
                      .ToListAsync();
        }


        public async Task<MedicalRecord> GetPrescriptionByIdAsync(int id)
        {
            return await _apicontext.prescriptions
                    .Include(r => r.Patient)
                    .Include(r => r.doctor)
                    .FirstOrDefaultAsync(r => r.Patient_id==id);
        }





        public async Task<MedicalRecord> AddAsync(MedicalRecord prescription)
        {
             _apicontext.AddAsync(prescription);
            await _apicontext.SaveChangesAsync();
            return prescription;



        }

        public async Task<IEnumerable<MedicalRecord>> GetbyPatientid(int PatientId)
        {
            return await _apicontext.prescriptions
                    .Include(r => r.Patient_id == PatientId)
                    .Include(r => r.doctor)
                    .ToListAsync();
        }

      
       
    }
}
