using Hospital_Management.Model;

namespace Hospital_Management.Services.IServices
{
    public interface  IDepartmentServices
    {

        public Task<IEnumerable<Department>> GetAlldepartment();

        public Task<Department> GetDepartmentbyID(int id);
        public Task<Department> CreateDepartment(Department department);
        public Task<bool>  UpdateDepartment(Department department);
        public Task<bool> DeleteDepartment(int id);



    }
}
