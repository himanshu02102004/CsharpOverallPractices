using System.ComponentModel.DataAnnotations;

namespace CRUDTASK_CODE.Models
{
    public class Product
    {
        [Key]
        public int PropId { get; set; }

        public string PropName { get; set; }

        public Decimal PropPrice { get; set; }

        public int  CategoryId  { get; set; }

        public Category Category { get; set; }
    }
}
