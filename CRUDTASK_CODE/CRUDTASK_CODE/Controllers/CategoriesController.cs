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
        private readonly ApiContext productContext;

        public CategoriesController(ApiContext productContext)
        {
            this.productContext = productContext;
        }




        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            var categories = await productContext.Categories
                .Include(c => c.Products)
                .Select(c => new CategoryDTO
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDTO
                    {
                        PropId = p.PropId,
                        PropName = p.PropName,
                        PropPrice = p.PropPrice
                    }).ToList()
                }).ToListAsync();

            return Ok(categories);
        }








        [HttpGet("GetCategoryID/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category =await productContext.Categories
                                             .Include(c => c.Products)
                                            .FirstOrDefaultAsync(x => x.CategoryId == id);


            if (category == null)
                return NotFound("category not found");
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

            await productContext.Categories.AddAsync(category);
            await productContext.SaveChangesAsync();
            return Ok("Category Added Successfully");
        }






        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var existingCategory = await productContext.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }

            existingCategory.Name = category.Name;
            productContext.Entry(existingCategory).State = EntityState.Modified;
            await productContext.SaveChangesAsync();
            return Ok("Category Updated Successfully");
        }







        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await productContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            productContext.Categories.Remove(category);
            await productContext.SaveChangesAsync();
            return Ok("Category Deleted Successfully");
        }
    }

}
