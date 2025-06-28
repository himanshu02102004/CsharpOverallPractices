using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Model
{
    public class Category
    {
        [Key]
        public int CateID { get; set; }
        public string CateName { get; set; }
        

        public ICollection<Product> Products { get; set; }

    }
}
