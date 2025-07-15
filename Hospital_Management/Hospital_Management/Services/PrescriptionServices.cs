using Hospital_Management.Database;
using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Services
{
    public class PrescriptionServices : IPrescriptionServices
    {

        private readonly Apicontext _apicontext;

        public PrescriptionServices( Apicontext apicontext)
        {
         _apicontext = apicontext;   
        }




        public async Task<IEnumerable<Prescription>> GetPrescriptionListAsync()
        {
            return await _apicontext.prescriptions
                      .Include(r => r.Patient)
                      .Include(r => r.doctor)
                      .ToListAsync();
        }


        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _apicontext.prescriptions
                    .Include(r => r.Patient)
                    .Include(r => r.doctor)
                    .FirstOrDefaultAsync(r => r.Patient_id==id);
        }





        public async Task<Prescription> AddAsync(Prescription prescription)
        {
             _apicontext.AddAsync(prescription);
            await _apicontext.SaveChangesAsync();
            return prescription;



        }

        public async Task<IEnumerable<Prescription>> GetbyPatientid(int PatientId)
        {
            return await _apicontext.prescriptions
                    .Include(r => r.Patient_id == PatientId)
                    .Include(r => r.doctor)
                    .ToListAsync();
        }

      
       
    }
}
