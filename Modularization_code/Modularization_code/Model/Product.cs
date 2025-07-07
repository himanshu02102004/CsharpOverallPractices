using System.ComponentModel.DataAnnotations;

namespace Modularization_code.Model
{
    public class Product
    {
        [Key]
        public int PropId{ get; set; }
        public  string PropName { get; set; }
        public decimal PropPrice { get; set; }
    }
}
