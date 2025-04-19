using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext productContext;

        public CategoriesController(ApiContext productContext)
        {
           _productContext = productContext;
        }




        [HttpGet("GetCategories")]
        public List<Category> GetCategories()
        {
            return productContext.Categories.Include(c => c.Products).ToList();
        }

        [HttpGet("GetCategoryID/{id}")]
        public Category GetCategory(int id)
        {
            return productContext.Categories.Include(c => c.Products)
                                            .FirstOrDefault(x => x.CategoryId == id);
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

            productContext.Categories.Add(category);
            productContext.SaveChanges();
            return Ok("Category Added Successfully");
        }







        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var existingCategory = productContext.Categories.Find(id);
            if (existingCategory == null)
            {
                return "Category not found";
            }

            existingCategory.Name = category.Name;
            productContext.Entry(existingCategory).State = EntityState.Modified;
            productContext.SaveChanges();
            return "Category Updated Successfully";
        }







        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = productContext.Categories.Find(id);
            if (category == null)
            {
                return "Category not found";
            }

            productContext.Categories.Remove(category);
            productContext.SaveChanges();
            return "Category Deleted Successfully";
        }
    }

}
