using System.ComponentModel.DataAnnotations;

namespace test1.Model
{
    public class Product
    {
        [Key]
        public int Prod_Id { get; set; }
        public string Prod_Name { get; set; }
        public string Prod_Description { get; set; } = string.Empty;
    }
}
