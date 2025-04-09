using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTASK_CODE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase


    {
        private readonly ProductContext productContext;

        public ProductController(ProductContext productContext)
        {

            this.productContext = productContext;
        }




        [HttpPost]
        [Route("AddProduct")]
        public string AddProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                PropName = productDto.PropName,
                PropPrice = productDto.PropPrice,
                CategoryId = productDto.CategoryId
            };

            productContext.Products.Add(product);
            productContext.SaveChanges();
            return "Product Added Successfully";
        }


        [HttpGet("GetProductID/{id}")]
        public ActionResult<Product> GetProduct(int id)

        {
            return productContext.Products.Where(x => x.PropId == id).FirstOrDefault();
        }


        [HttpPost]
        [Route("Addthisproduct")]
        public string Addproduct(Product product)
        {
            string response = string.Empty;

            productContext.Products.Add(product);

            productContext.SaveChanges();
            return "Product Added Successfully";
        }


        [HttpPut]
        [Route("UpdatetheProduct")]

        public string UpdateProduct(Product product)
        {
            productContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            productContext.SaveChanges();
            return "Product Updated Successfully";
        }


        [HttpDelete]
        [Route("DeleteProduct")]
        public string DeleteProduct(int id)
        {
            Product product = productContext.Products.Where(x => x.PropId == id).FirstOrDefault();
            productContext.Products.Remove(product);
            productContext.SaveChanges();
            return "Product Deleted Successfully";
        }

    }
}
