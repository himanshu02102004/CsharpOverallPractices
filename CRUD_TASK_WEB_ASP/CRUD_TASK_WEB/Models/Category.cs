using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Models
{
    public class Category
    {


        public int CategoryId { get; set; }

        public string Name { get; set; }



        // one to many relationships
        public List<Product> Products { get; set; }





    }
}
