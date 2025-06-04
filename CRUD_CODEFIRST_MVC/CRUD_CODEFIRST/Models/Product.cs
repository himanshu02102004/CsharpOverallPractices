using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_CODEFIRST.Models
{
    public class Product
    {

        [Key]
        public int PropId { get; set; }

        [Column("productname",TypeName ="varchar(100)")]
        public string Propname { get; set; }

       
        public decimal price { get; set; }



    }
}
