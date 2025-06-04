using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.Services.IServices;
using CRUDTASK_CODE.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TASK_WEB.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ApiContext _db;
        public CategoryService(ApiContext db)
        {
            _db = db;
        }
        public async Task<Category> GetCategory(int id)
        {
            var category = await _db.Categories
                                                .Include(c => c.Products)
                                                .FirstOrDefaultAsync(x => x.CategoryId == id);
            return category;
        }
    }
}
