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
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name, // do NOT set CategoryId here
                Products = categoryDto.Products?.Select(p => new Product
                {
                    PropName = p.PropName,
                    PropPrice = p.PropPrice,
                    // do NOT set ProductId
                }).ToList()
            };

            productContext.Categories.Add(category);
            productContext.SaveChanges();
            return Ok("Category Added Successfully");
        }







        [HttpPut("UpdateCategory/{id}")]
        public string UpdateCategory(int id, Category category)
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
        public string DeleteCategory(int id)
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
