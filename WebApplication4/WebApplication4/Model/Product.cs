using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Model
{
    public class Product
    {
        [Key]
        public int Proid{ get; set; }
        public string Proname { get; set; }

        public string Prodesc { get; set; }
        
        Category Category { get; set; }
        public int CateID { get; set; } // Foreign key to Category

    }



}
