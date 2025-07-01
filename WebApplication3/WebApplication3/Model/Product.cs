using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Product
    {
        [Key]
        public int Propid { get; set; }
        public string Name { get; set; }
        public string price { get; set; }


        public int CategoryId { get; set; }
        Category category { get; set; }


    }
}
