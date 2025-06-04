using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.Services.IServices;
using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _productContext;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ApiContext productContext, ICategoryService categoryService)
        {
            _productContext = productContext;
            _categoryService = categoryService;
        }




        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _productContext.Categories
                                                  .Include(c => c.Products)
                                                  .ToListAsync();
            return Ok(categories);
        }



        [HttpGet("GetCategoryID/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category == null)
                return NotFound("Category not found");
            return Ok(category);
        }



        [HttpPost("AddThisCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Products = categoryDto.Products?.Select(p => new Product
                {
                    PropName = p.PropName,
                    PropPrice = p.PropPrice
                }).ToList()
            };

            await _productContext.Categories.AddAsync(category);
            await _productContext.SaveChangesAsync();

            return Ok("Category Added Successfully");
        }



        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var existingCategory = await _productContext.Categories.FindAsync(id);
            if (existingCategory == null)
                return NotFound("Category not found");

            existingCategory.Name = category.Name;

            _productContext.Entry(existingCategory).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            return Ok("Category Updated Successfully");
        }



        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _productContext.Categories.FindAsync(id);
            if (category == null)
                return NotFound("Category not found");

            _productContext.Categories.Remove(category);
            await _productContext.SaveChangesAsync();

            return Ok("Category Deleted Successfully");
        }
    }
}
