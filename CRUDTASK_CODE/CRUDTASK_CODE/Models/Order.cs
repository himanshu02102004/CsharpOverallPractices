using System.ComponentModel.DataAnnotations;

namespace CRUDTASK_CODE.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }  // Primary key

        public string CustomerName { get; set; }
        public string ID { get; set; } // FK to Users (optional but clear)

        public DateTime OrderDate { get; set; } 

        public List<OrderItem> OrderItems { get; set; }
    }
}
